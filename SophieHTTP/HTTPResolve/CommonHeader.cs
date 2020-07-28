using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP
{
    namespace HTTPResolve
    {
        class CommonHeader : HTTPHeader
        {
            public CommonHeader(string key, Object val)
            {
                HeaderKey = key;
                Value = val;
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
                        HeaderValue = value;
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
            public override string getHeaderString()
            {
                return Key + ":" + (string)HeaderValue;
            }
        }
    }
    
}
