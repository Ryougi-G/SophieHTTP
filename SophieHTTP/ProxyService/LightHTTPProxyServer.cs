using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using SophieHTTP.HTTPResolve;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace SophieHTTP.ProxyService
{
    public class LightHTTPProxyServer
    {
        private int port;
        private IPAddress localAddress;
        private TcpListener server;
        private bool isStarted;
        public int Port
        {
            get
            {
                return port;
            }
        }
        public IPAddress IPAddress
        {
            get
            {
                return localAddress;
            }
        }
        public LightHTTPProxyServer(IPAddress Address,int PortToBind)
        {
            this.port = PortToBind;
            this.localAddress = Address;
            isStarted = false;
        }
        public void Start()
        {
            if (!isStarted)
            {
                server = new TcpListener(localAddress, port);
                server.Start();
                isStarted = true;
                Thread listeningThread = new Thread(new ThreadStart(this.Listening));
                listeningThread.IsBackground = true;
                listeningThread.Start();
            }
            else
            {
                throw new Exception("The server has already start");
            }
        }
        public void Start(int backlog)
        {
            if (!isStarted)
            {
                server = new TcpListener(localAddress, port);
                server.Start(backlog);
                isStarted = true;
                Thread listeningThread = new Thread(new ThreadStart(this.Listening));
                listeningThread.IsBackground = true;
                listeningThread.Start();
            }
            else
            {
                throw new Exception("The server has already start");
            }
        }
        private void Listening()
        {
            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread th = new Thread(new ParameterizedThreadStart(this.dealProxyRequest));
                    th.IsBackground = true;
                    th.Start(client);
                }
            }
            catch(Exception ex)
            {
                return;
            }
            
        }
        private void dealProxyRequest(object obj)
        {
            try
            {
                TcpClient client = (TcpClient)obj;
                Console.WriteLine(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
                HTTPRequest request;
                using (BinaryReader breader = new BinaryReader(client.GetStream()))
                {
                    byte[] b = new byte[1];
                    string ht = "";
                    List<string> rawHeaders = new List<string>();
                    while (client.GetStream().CanRead && client.GetStream().DataAvailable)
                    {
                        b[0] = breader.ReadByte();
                        ht += Encoding.ASCII.GetString(b);

                        if (ht.Contains("\r\n"))
                        {
                            rawHeaders.Add(ht);
                            if (ht == "\r\n")
                            {
                                break;
                            }
                            ht = "";
                        }
                    }
                    string sr = "";
                    foreach (string st in rawHeaders)
                    {
                        sr += st;
                    }
                    if (rawHeaders.Count == 0)
                    {
                        client.Dispose();
                        return;
                    }
                    request = SophieHTTP.HTTPResolve.HTTPResolve.ResolveHTTPRequest(Encoding.ASCII.GetBytes(sr));
                    if (request.Method.MethodName == HTTPMethod.CONNECT.MethodName)
                    {
                        request.Url = new Uri("https://" + request.Url.OriginalString + "/");
                        TcpClient remoteServer = new TcpClient();
                        try
                        {

                            remoteServer.Connect(Dns.GetHostEntry(request.Url.Host).AddressList[0], Convert.ToInt32(request.Url.Port));
                            HTTPResponse resp = new HTTPResponse(HTTPVersion.HTTP11, HTTPStatusCode.ConnectionEstablished, new List<HTTPHeader>());
                            if (client.Connected)
                            {
                                client.GetStream().Write(resp.GetRawBytes(), 0, resp.GetRawBytes().Length);
                            }
                            else
                            {
                                client.Dispose();
                                return;
                            }

                            NetworkStream serverStream = remoteServer.GetStream();
                            NetworkStream clientStream = client.GetStream();
                            while (client.Connected)
                            {
                                Thread.Sleep(1);
                                if (serverStream.CanRead && clientStream.CanRead && serverStream.CanWrite && clientStream.CanWrite)
                                {
                                    try
                                    {
                                        if (clientStream.DataAvailable)
                                        {
                                            byte[] buf = new byte[1024];
                                            int size = clientStream.Read(buf, 0, 1024);
                                            serverStream.Write(buf, 0, size);
                                        }
                                        if (serverStream.DataAvailable)
                                        {
                                            byte[] buf = new byte[1024];
                                            int size = serverStream.Read(buf, 0, 1024);
                                            clientStream.Write(buf, 0, size);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            remoteServer.Dispose();
                            client.Dispose();
                        }
                        catch (SocketException ex)
                        {
                            HTTPResponse resp = new HTTPResponse(HTTPVersion.HTTP11, HTTPStatusCode.BadGateway, new List<HTTPHeader>());
                            resp.Content = Encoding.Unicode.GetBytes(ex.Message);
                            client.GetStream().Write(resp.GetRawBytes(), 0, resp.GetRawBytes().Length);
                            client.Dispose();
                        }

                    }
                    else
                    {
                        if (request.Version==HTTPVersion.HTTP09||request.Version==HTTPVersion.HTTP10)
                        {
                            if (client.Connected)
                            {
                                HTTPResponse resp = new HTTPResponse(request.Version, HTTPStatusCode.HttpVersionNotSupported, new List<HTTPHeader>());
                                resp.Content = Encoding.UTF8.GetBytes("死妈玩意赶紧滚回去升级你的浏览器，别让我看到你个懒狗还在用低于HTTP1.1版本的浏览器");
                                resp.AddHeader(new CommonHeader("Content-Type: text/html; charset=utf-8"));
                                client.GetStream().Write(resp.GetRawBytes(), 0, resp.GetRawBytes().Length);
                            }
                            else
                            {
                                client.Dispose();
                                return;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }
    }
}
