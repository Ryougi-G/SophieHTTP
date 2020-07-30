using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SophieHTTP
{
    namespace HTTPResolve
    {
        public static class HTTPResolve
        {
            public static HTTPRequest ResolveHTTPRequest(byte[] rawBytes)
            {
                HTTPRequest result = new HTTPRequest();

                List<string> rawHeaders = new List<string>();

                int pos = 0;

                string ht = "";

                while (pos < rawBytes.Length)
                {
                    byte tb=rawBytes[pos];

                    if (tb == '\r')
                    {
                        if (rawBytes[pos+1]=='\n')
                        {
                            rawHeaders.Add(ht);
                            ht = "";
                            pos += 2;
                            continue;
                        }
                        
                    }
                    ht += (char)tb;

                    pos += 1;
                }
                string[] firstLine = rawHeaders[0].Split(' ');

                rawHeaders.Remove(rawHeaders[0]);

                result.Method = new HTTPMethod(firstLine[0]);

                bool bre = Uri.TryCreate(firstLine[1], UriKind.RelativeOrAbsolute, out result.Url);

                result.Version = firstLine[2];

                if (rawBytes.Length >= pos + 1)
                {
                    result.Content = new byte[rawBytes.Length - pos];

                    for (int i = pos; i < rawBytes.Length; i++)
                    {
                        result.Content[i - pos] = rawBytes[i];
                    }
                }
                else
                {
                    result.Content = null;
                }

                foreach (string s in rawHeaders)
                {
                    string key = "", value = "";

                    int i = 0;

                    while (s[i] != ':')
                    {
                        if (s[i] != ' ')
                            key += s[i];
                        i++;
                    }
                    i++;

                    bool flag = false;

                    while (i < s.Length)
                    {
                        if (s[i] == ' ' && !flag)
                        {

                        }
                        else
                        {
                            flag = true;
                            value += s[i];
                        }
                        i++;
                    }

                    result.AddHeader(new CommonHeader(key, value));
                }
                return result;
            }
            public static HTTPResponse ResolveHTTPResponse(byte[] rawBytes)
            {
                HTTPResponse result=new HTTPResponse()

                List<string> rawHeaders = new List<string>();

                int pos = 0;

                string ht = "";

                while (pos < rawBytes.Length)
                {
                    byte tb = rawBytes[pos];

                    if (tb == '\r')
                    {
                        if (rawBytes[pos + 1] == '\n')
                        {
                            rawHeaders.Add(ht);
                            ht = "";
                            pos += 2;
                            continue;
                        }

                    }
                    ht += (char)tb;

                    pos += 1;
                }
            }
            
        }
    }
    
}
