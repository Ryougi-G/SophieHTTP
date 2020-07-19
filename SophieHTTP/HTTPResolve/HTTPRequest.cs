using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP.HTTPResolve
{
    class HTTPRequest
    {
        public HTTPMethod Method;
        public Uri Url;
        public string Version;
        private List<HTTPHeader> Headers;
        string Content="";
        public HTTPRequest(HTTPMethod method,Uri uri,string version,List<HTTPHeader> headers,string content="")
        {
            Method = method;
            this.Url = uri;
            Version = version;
            Headers = headers;
            Content = content;
        }
        public HTTPHeader FindHeader(string key)
        {
            foreach(HTTPHeader current in Headers)
            {
                if (current.Key == key)
                    return current;
            }
            return null;
        }
        public void AddHeader(HTTPHeader header)
        {
            Headers.Add(header);
        }
        public HTTPHeader RemoveHeader(string key)
        {
            foreach (HTTPHeader current in Headers)
            {
                if (current.Key == key)
                {
                    HTTPHeader t = current;
                    Headers.Remove(current);
                    return t;   
                } 
            }
            return null;
        }
        public string GetRawString()
        {
            string result = "";
            result += Method.MethodName + " " +Url.ToString()+" "+ Version+"\r\n";
            foreach(HTTPHeader header in Headers)
            {
                result += header.getHeaderString() + "\r\n";
            }
            result += "\r\n";
            result += Content;
            return result;
        }
    }
}
