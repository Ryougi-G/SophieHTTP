using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP.HTTPResolve
{
    class HTTPMethod
    {
        static HTTPMethod GET;
        static HTTPMethod POST;
        static HTTPMethod PUT;
        static HTTPMethod HEAD;
        static HTTPMethod DELETE;
        static HTTPMethod CONNECT;
        static HTTPMethod OPTIONS;
        static HTTPMethod TRACE;
        static HTTPMethod PATCH;
        private string HTTPMethodName;
        public string MethodName
        {
            get;
            set;
        }
        static HTTPMethod()
        {
            GET = new HTTPMethod("GET");
            POST = new HTTPMethod("POST");
            PUT = new HTTPMethod("PUT");
            HEAD = new HTTPMethod("HEAD");
            DELETE = new HTTPMethod("DELETE");
            CONNECT = new HTTPMethod("CONNECT");
            OPTIONS = new HTTPMethod("OPTIONS");
            TRACE = new HTTPMethod("TRACE");
            PATCH = new HTTPMethod("PATCH");
        }
        public HTTPMethod(string methodName)
        {
            this.HTTPMethodName = methodName;
        }
    }
    static class HTTPVersion
    {
        static string HTTP09 = "HTTP/0.9";
        static string HTTP10 = "HTTP/1.0";
        static string HTTP11 = "HTTP/1.1";
        static string HTTP20 = "HTTP/2.0";
    }

}
