using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP.HTTPResolve
{
    class TestHeader : HTTPHeader
    {
        public override string getHeaderString()
        {
            return this.Key + ":" + this.Value.ToString();
        }
    }
}
