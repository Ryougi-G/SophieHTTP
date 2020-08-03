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
