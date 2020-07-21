using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP.HTTPResolve
{
    class HTTPMethod
    {
        static HTTPMethod GET;
        static HTTPMethod POST;
        static HTTPMethod PUT;
        static HTTPMethod HEAD;
        static HTTPMethod DELETE;
        static HTTPMethod CONNECT;
        static HTTPMethod OPTIONS;
        static HTTPMethod TRACE;
        static HTTPMethod PATCH;
        private string HTTPMethodName;
        public string MethodName
        {
            get;
            set;
        }
        static HTTPMethod()
        {
            GET = new HTTPMethod("GET");
            POST = new HTTPMethod("POST");
            PUT = new HTTPMethod("PUT");
            HEAD = new HTTPMethod("HEAD");
            DELETE = new HTTPMethod("DELETE");
            CONNECT = new HTTPMethod("CONNECT");
            OPTIONS = new HTTPMethod("OPTIONS");
            TRACE = new HTTPMethod("TRACE");
            PATCH = new HTTPMethod("PATCH");
        }
        public HTTPMethod(string methodName)
        {
            this.HTTPMethodName = methodName;
        }
    }
    static class HTTPVersion
    {
        static string HTTP09 = "HTTP/0.9";
        static string HTTP10 = "HTTP/1.0";
        static string HTTP11 = "HTTP/1.1";
        static string HTTP20 = "HTTP/2.0";
    }
    class HTTPStatusCode
    {
        int Code;
        string Message;
        public HTTPStatusCode(int code,string msg)
        {
            this.Code = code;
            this.Message = msg;
        }
        static HTTPStatusCode Accepted = new HTTPStatusCode(202,"Accepted");// 	202
        static HTTPStatusCode Ambiguous = new HTTPStatusCode(300, "Ambiguous");//Ambiguous 	300
        static HTTPStatusCode BadGateway = new HTTPStatusCode(502, "BadGateway");
        static HTTPStatusCode BadRequest = new HTTPStatusCode(400, "BadRequest");
        static HTTPStatusCode Conflict = new HTTPStatusCode(409, "Conflict");
        static HTTPStatusCode Continue = new HTTPStatusCode(100, "Continue");
        static HTTPStatusCode Created = new HTTPStatusCode(201, "Created");
        static HTTPStatusCode ExpectationFailed = new HTTPStatusCode(417, "ExpectationFailed");
        static HTTPStatusCode Forbidden = new HTTPStatusCode(403, "Forbidden");
        static HTTPStatusCode Found = new HTTPStatusCode(302, "Found");
        static HTTPStatusCode GatewayTimeout = new HTTPStatusCode(504, "GatewayTimeout");
        static HTTPStatusCode Gone = new HTTPStatusCode(410, "Gone");
        static HTTPStatusCode HttpVersionNotSupported = new HTTPStatusCode(505, "HttpVersionNotSupported");
        static HTTPStatusCode InternalServerError = new HTTPStatusCode(500, "InternalServerError");
        static HTTPStatusCode LengthRequired = new HTTPStatusCode(411, "LengthRequired");
        static HTTPStatusCode MethodNotAllowed = new HTTPStatusCode(405, "MethodNotAllowed");
        static HTTPStatusCode Moved = new HTTPStatusCode(301, "Moved");
        static HTTPStatusCode MovedPermanently = new HTTPStatusCode(301, "MovedPermanently");
        static HTTPStatusCode MultipleChoices = new HTTPStatusCode(300, "MultipleChoices");
        static HTTPStatusCode NoContent = new HTTPStatusCode(204, "NoContent");
        static HTTPStatusCode NonAuthoritativeInformation = new HTTPStatusCode(203, "NonAuthoritativeInformation");
        static HTTPStatusCode NotAcceptable = new HTTPStatusCode(406, "NotAcceptable");
        static HTTPStatusCode NotFound = new HTTPStatusCode(404, "NotFound");
        static HTTPStatusCode NotImplemented = new HTTPStatusCode(501, "NotImplemented");
        static HTTPStatusCode NotModified = new HTTPStatusCode(304,"NotModified");
        static HTTPStatusCode OK = new HTTPStatusCode(200, "OK");
        static HTTPStatusCode PartialContent = new HTTPStatusCode(206, "PartialContent");
        static HTTPStatusCode PaymentRequired = new HTTPStatusCode(402, "PaymentRequired");
        static HTTPStatusCode PreconditionFailed = new HTTPStatusCode(412, "PreconditionFailed");
        static HTTPStatusCode ProxyAuthenticationRequired = new HTTPStatusCode(407, "ProxyAuthenticationRequired");
        static HTTPStatusCode Redirect = new HTTPStatusCode(302, "Redirect");
        static HTTPStatusCode RedirectKeepVerb = new HTTPStatusCode(307, "RedirectKeepVerb");
        static HTTPStatusCode RedirectMethod = new HTTPStatusCode(303, "RedirectMethod");
        static HTTPStatusCode RequestedRangeNotSatisfiable = new HTTPStatusCode(416, "RequestedRangeNotSatisfiable");
        static HTTPStatusCode RequestEntityTooLarge = new HTTPStatusCode(413, "RequestEntityTooLarge");
        static HTTPStatusCode RequestTimeout = new HTTPStatusCode(408, "RequestTimeout");
        static HTTPStatusCode RequestUriTooLong = new HTTPStatusCode(414, "RequestUriTooLong");
        static HTTPStatusCode ResetContent = new HTTPStatusCode(205, "ResetContent");
        static HTTPStatusCode SeeOther = new HTTPStatusCode(303, "SeeOther");
        static HTTPStatusCode ServiceUnavailable = new HTTPStatusCode(503, "ServiceUnavailable");
        static HTTPStatusCode SwitchingProtocols = new HTTPStatusCode(101, "SwitchingProtocols");
        static HTTPStatusCode TemporaryRedirect = new HTTPStatusCode(307, "TemporaryRedirect");
        static HTTPStatusCode Unauthorized = new HTTPStatusCode(401, "Unauthorized");
        static HTTPStatusCode UnsupportedMediaType = new HTTPStatusCode(415, "UnsupportedMediaType");
        static HTTPStatusCode Unused = new HTTPStatusCode(306, "Unused");
        static HTTPStatusCode UpgradeRequired = new HTTPStatusCode(426, "UpgradeRequired");
        static HTTPStatusCode UseProxy = new HTTPStatusCode(305, "UseProxy");
        static HTTPStatusCode ConnectionEstablished = new HTTPStatusCode(200, "Connection established");
    }
}
