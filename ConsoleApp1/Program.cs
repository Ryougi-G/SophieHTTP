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
            string s = File.ReadAllText("req.txt");
            HTTPRequest req = HTTPResolve.ResolveHTTPRequest(Encoding.ASCII.GetBytes(s));
            using (StreamWriter writer = new StreamWriter(new FileStream("Res.txt", FileMode.OpenOrCreate)))
            {
                writer.WriteLine("HTTPVer:" + req.Version);
                writer.WriteLine("Method:" + req.Method.MethodName);
                writer.WriteLine("URI:" + req.Url.OriginalString);
                foreach(HTTPHeader header in req.HTTPHeaders)
                {
                    writer.WriteLine("Header:" + header.getHeaderString());
                }
            }
            /*
            TcpListener server = new TcpListener(IPAddress.Any, 4444);
            server.Start();
            worker ws = new worker();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                string res = "";
                using(StreamReader reader=new StreamReader(client.GetStream()))
                {
                    while (true)
                    {
                        string t;
                        t = reader.ReadLine();
                        if (t == "")
                        {
                            res += "\r\n";
                            break;
                        }
                        else
                        {
                            res += t + "\r\n";
                        }
                    }
                    
                }
                HTTPRequest request = HTTPResolve.ResolveHTTPRequest(Encoding.ASCII.GetBytes(res));
                //TcpClient remoteServer = new TcpClient();
                //remoteServer.Connect(request.Url.Host, request.Url.Port);
                Console.WriteLine(res);
                //Thread t = new Thread(new ParameterizedThreadStart(ws.work));
                //t.Start(client);
            
            }
            */
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
            if(client.GetStream().CanRead&& client.GetStream().CanWrite)
            {
                try
                {
                    
                }
                catch (Exception e)
                {

                }
                
            }
        }
    }
}
