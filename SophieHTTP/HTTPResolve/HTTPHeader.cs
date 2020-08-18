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
            public abstract string Key {
                get; set;
            }
            public abstract Object Value
            {
                get;set;
            }
            public abstract string GetValueString();
            public abstract string GetHeaderString();
        }
    }
    
}
