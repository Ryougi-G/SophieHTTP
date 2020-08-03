using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP
{
    namespace HTTPResolve
    {
        public class HTTPRequest
        {
            public HTTPMethod Method;

            public Uri Url;

            public string Version;

            private List<HTTPHeader> Headers;

            public byte[] Content;

            public HTTPRequest(HTTPMethod method, Uri uri, string version, List<HTTPHeader> headers, byte[] content = null)
            {

                Method = method;

                this.Url = uri;

                Version = version;

                Headers = headers;

                Content = content;

            }
            public HTTPRequest()
            {
                Method = null;

                Url = null;

                Version = null;

                Headers = new List<HTTPHeader>();

                Content = null;
            }
            public List<HTTPHeader> HTTPHeaders
            {
                get
                {
                    return Headers;
                }
                set
                {
                    Headers = value;
                }
            }
            public HTTPHeader FindHeader(string key)
            {
                foreach (HTTPHeader current in Headers)
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
            public byte[] GetRawByte()
            {

                string result = "";

                result += Method.MethodName + " " + Url.ToString() + " " + Version + "\r\n";

                foreach (HTTPHeader header in Headers)
                {

                    result += header.getHeaderString() + "\r\n";

                }
                result += "\r\n";

                byte[] bresult;

                if (Content != null)
                {
                    bresult= new byte[Encoding.ASCII.GetByteCount(result) + Content.Length];
                }
                else
                {
                    bresult = new byte[Encoding.ASCII.GetByteCount(result)];
                }
                 
                byte[] tr = Encoding.ASCII.GetBytes(result);

                for (int i = 0; i < tr.Length; i++)
                {
                    bresult[i] = tr[i];
                }

                if (Content != null)
                    for (int i = tr.Length; i < Encoding.ASCII.GetByteCount(result) + Content.Length; i++)
                    {

                        bresult[i] = Content[i];

                    }

                return bresult;
            }
        }
    }
    
}
