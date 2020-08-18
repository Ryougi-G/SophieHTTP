using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP
{
    namespace HTTPResolve
    {
        public class CommonHeader : HTTPHeader
        {
            protected string HeaderValue;
            protected string HeaderKey;
            public CommonHeader(string key, Object val)
            {
                HeaderKey = key;
                Value = val;
            }
            public CommonHeader(string rawHeader)
            {
                string key = "", value = "";

                int i = 0;

                while (rawHeader[i] != ':')
                {
                    if (rawHeader[i] != ' ')
                        key += rawHeader[i];
                    i++;
                }
                i++;

                bool flag = false;

                while (i < rawHeader.Length)
                {
                    if (rawHeader[i] == ' ' && !flag)
                    {

                    }
                    else
                    {
                        flag = true;
                        value += rawHeader[i];
                    }
                    i++;
                }
                HeaderValue = value;
                HeaderKey = key;
            }
            public override string Key {
                get
                {
                    return HeaderKey;
                }
                set
                {
                    HeaderKey = value;
                }
            }
            public override Object Value
            {
                get
                {
                    return HeaderValue;
                }
                set
                {
                    if (value is string)
                    {
                        HeaderValue = (string)value;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
            public override string GetValueString()
            {
                return (string)Value;
            }
            public override string GetHeaderString()
            {
                return Key + ":" + (string)HeaderValue;
            }
        }
    }
    
}
