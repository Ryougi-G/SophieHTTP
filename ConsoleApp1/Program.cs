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
            LightHTTPProxyServer server = new LightHTTPProxyServer(IPAddress.Any, 11451);
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
    
}
