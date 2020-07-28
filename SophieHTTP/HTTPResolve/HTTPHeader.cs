using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP
{
    namespace HTTPResolve
    {
       public abstract class HTTPHeader
        {
            protected string HeaderKey;
            protected Object HeaderValue;
            public HTTPHeader(string key, Object val)
            {
                HeaderKey = key;
                HeaderValue = val;
            }
            public HTTPHeader()
            {
                HeaderValue = null;
                HeaderKey = null;
            }
            public virtual string Key
            {
                get
                {
                    return Key;
                }
                set
                {
                    HeaderKey = value;
                }
            }
            public virtual Object Value
            {
                get
                {
                    return HeaderValue;
                }
                set
                {
                    HeaderValue = value;
                }
            }
            public abstract string GetValueString();
            public abstract string getHeaderString();
        }
    }
    
}
