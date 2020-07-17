using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP.HTTPResolve
{
    abstract class HTTPHeader
    {
        protected string HeaderKey;
        protected Object HeaderValue;
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
        public abstract string getHeaderString();
    }
}
