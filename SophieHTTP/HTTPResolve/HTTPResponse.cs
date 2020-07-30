using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SophieHTTP
{
    namespace HTTPResolve
    {
        public class HTTPResponse
        {
            string Version;
            HTTPStatusCode StatusCode;
            List<HTTPHeader> Headers;
            byte[] Content;
            public HTTPResponse(string ver, HTTPStatusCode code, List<HTTPHeader> headers)
            {
                Version = ver;
                StatusCode = code;
                Headers = headers;
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
            public byte[] GetRawString()
            {
                string result = "";
                result += Version + " " + StatusCode.Code + " " + StatusCode.Message + "\r\n";
                foreach (HTTPHeader header in Headers)
                {
                    result += header.getHeaderString() + "\r\n";
                }
                result += "\r\n";
                byte[] bresult = new byte[Encoding.ASCII.GetByteCount(result) + Content.Length];
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
