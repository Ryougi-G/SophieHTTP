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
            static HTTPRequest ResolveHTTPRequest(byte[] rawBytes)
            {
                HTTPRequest result = new HTTPRequest();
                List<string> rawHeaders = new List<string>();
                int pos = 0;
                string ht = "";
                while (pos < rawBytes.Length)
                {
                    byte[] tb = new byte[2];
                    tb[0] = rawBytes[pos];
                    tb[1] = rawBytes[pos + 1];
                    pos += 2;
                    string t = Encoding.ASCII.GetString(tb);
                    if (t == "\r\n")
                    {
                        if (ht == "")
                        {
                            break;
                        }
                        rawHeaders.Add(ht);
                        ht = "";
                    }
                }
                string[] firstLine = rawHeaders[0].Split(' ');
                rawHeaders.Remove(rawHeaders[0]);
                result.Method = new HTTPMethod(firstLine[0]);
                result.Url = new Uri(firstLine[1]);
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
            static HTTPRequest ResolveHTTPRequest(Stream rawStream)
            {
                HTTPRequest result = new HTTPRequest();
                List<string> rawHeaders = new List<string>();
                using (BinaryReader bReader = new BinaryReader(rawStream))
                {
                    byte[] bt = new byte[1];
                    string st = "";
                    while (rawStream.CanRead)
                    {
                        bt[0] = bReader.ReadByte();
                        st += Encoding.ASCII.GetString(bt);
                        if (st == "\r\n")
                        {
                            break;
                        }
                        else if (st.Contains("\r\n"))
                        {
                            st = st.Remove(st.Length - 2);
                            rawHeaders.Add(st);
                            st = "";
                        }
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
                    HTTPHeader ContentLength = result.FindHeader("Content-length");
                    if (ContentLength != null)
                    {
                        int length = Convert.ToInt32((string)ContentLength.Value);
                        byte[] content = new byte[length];
                        for (int i = 0; i < length; i++)
                        {
                            content[i] = bReader.ReadByte();
                        }
                        result.Content = content;
                    }
                    else
                    {
                        result.Content = null;
                    }
                }
                return result;
            }
        }
    }
    
}
