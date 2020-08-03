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
            TcpClient client = server.AcceptTcpClient();
            HTTPRequest request;
            using(BinaryReader breader=new BinaryReader(client.GetStream()))
            {
                byte[] b=new byte[1];
                string ht="";
                List<string> rawHeaders=new List<string>();
                while (client.GetStream().CanRead&& client.GetStream().DataAvailable)
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
                foreach(string st in rawHeaders)
                {
                    sr += st;
                }
                request = HTTPResolve.ResolveHTTPRequest(Encoding.ASCII.GetBytes(sr));
            }
            Console.WriteLine("Method:" + request.Method.MethodName + " Url:" + request.Url.OriginalString + " Version" + request.Version);
            Console.ReadLine();
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
