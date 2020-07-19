using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP.HTTPResolve
{
    class CommonHeader : HTTPHeader
    {
        public override Object Value {
            get
            {
                return HeaderValue;
            }
            set
            {
                HeaderValue = value;
            }
        }
        public override string getHeaderString()
        {
            return Key + ":" + (string)HeaderValue;
        }
    }
}
