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
using SophieHTTP.ProxyService;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            LigthHTTPProxyServer server = new LigthHTTPProxyServer(IPAddress.Any, 4444);
            server.Start();
            while (true)
            {
                Thread.Sleep(10000);
            }
        }
        void deal(TcpClient client)
        {

        }
    }
    class worker
    {
        public void work(object obj)
        {
            TcpClient client = (TcpClient)obj;
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
                request = HTTPResolve.ResolveHTTPRequest(Encoding.ASCII.GetBytes(sr));
                if (request.Method.MethodName == HTTPMethod.CONNECT.MethodName)
                {
                    request.Url = new Uri("https://" + request.Url.OriginalString + "/");
                    Console.WriteLine("ACP TO:" + request.Url.Host + " Method:" + request.Method.MethodName + " Port" + request.Url.Port);
                    Console.WriteLine(client.Connected);
                    TcpClient remoteServer = new TcpClient();
                    try
                    {
                        
                        remoteServer.Connect(Dns.GetHostEntry(request.Url.Host).AddressList[0], Convert.ToInt32(request.Url.Port));
                        Console.WriteLine(client.Connected);
                        HTTPResponse resp = new HTTPResponse(HTTPVersion.HTTP11, HTTPStatusCode.ConnectionEstablished, new List<HTTPHeader>());
                        if (client.Connected)
                        {
                            Console.WriteLine("CON ECT");
                            client.GetStream().Write(resp.GetRawBytes(), 0, resp.GetRawBytes().Length);
                        }
                        else
                        {
                            Console.WriteLine("Disposed");
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
            }
            
            /*
            Console.WriteLine("Method:" + request.Method.MethodName + " Url:" + request.Url.OriginalString + " Version：" + request.Version);
            foreach (CommonHeader header in request.HTTPHeaders)
            {
                Console.WriteLine("Key:" + header.Key + " Value:" + header.Value);
            }
            */
        }
    }
}
