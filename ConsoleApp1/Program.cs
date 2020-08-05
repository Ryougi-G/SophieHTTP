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

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any,4444);
            server.Start();
            worker wk = new worker();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Thread th = new Thread(new ParameterizedThreadStart(wk.work));
                th.Start(client);
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
                request = HTTPResolve.ResolveHTTPRequest(Encoding.ASCII.GetBytes(sr));
            }
            if (request.Method.MethodName == HTTPMethod.CONNECT.MethodName)
            {
                request.Url = new Uri("https://" + request.Url.OriginalString + "/");
                IPHostEntry entrys= Dns.GetHostEntry(request.Url.Host);
                TcpClient remoteServer=new TcpClient();
                bool flag = false;
                foreach(IPAddress adr in entrys.AddressList)
                {
                    try
                    {
                        remoteServer.Connect(adr, request.Url.Port);
                    }catch(SocketException ex)
                    {
                        continue;
                    }
                    flag = true;
                    break;
                }
                if (!flag)
                    return;
                if (client.Connected)
                {
                    client.Client.Send(new HTTPResponse(request.Version, HTTPStatusCode.ConnectionEstablished, new List<HTTPHeader>()).GetRawBytes());
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
