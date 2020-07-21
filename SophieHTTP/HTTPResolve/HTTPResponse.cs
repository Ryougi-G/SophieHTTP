using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SophieHTTP.HTTPResolve
{
    class HTTPResponse
    {
        string Version;
        HTTPStatusCode StatusCode;
        List<HTTPHeader> Headers;
        string Content;
    }
}
