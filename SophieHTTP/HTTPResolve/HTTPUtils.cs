using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP
{
    namespace HTTPResolve
    {
        public class HTTPMethod
        {
            public static HTTPMethod GET;
            public static HTTPMethod POST;
            public static HTTPMethod PUT;
            public static HTTPMethod HEAD;
            public static HTTPMethod DELETE;
            public static HTTPMethod CONNECT;
            public static HTTPMethod OPTIONS;
            public static HTTPMethod TRACE;
            public static HTTPMethod PATCH;
            private string HTTPMethodName;
            public string MethodName
            {
                get
                {
                    return HTTPMethodName;
                }
                set
                {
                    HTTPMethodName = value;
                }
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
        public static class HTTPVersion
        {
            public static string HTTP09 = "HTTP/0.9";
            public static string HTTP10 = "HTTP/1.0";
            public static string HTTP11 = "HTTP/1.1";
            public static string HTTP20 = "HTTP/2.0";
        }
        public class HTTPStatusCode
        {
            public int Code;
            public string Message;
            public HTTPStatusCode(int code, string msg)
            {
                this.Code = code;
                this.Message = msg;
            }
            public static HTTPStatusCode Accepted = new HTTPStatusCode(202, "Accepted");// 	202
            public static HTTPStatusCode Ambiguous = new HTTPStatusCode(300, "Ambiguous");//Ambiguous 	300
            public static HTTPStatusCode BadGateway = new HTTPStatusCode(502, "BadGateway");
            public static HTTPStatusCode BadRequest = new HTTPStatusCode(400, "BadRequest");
            public static HTTPStatusCode Conflict = new HTTPStatusCode(409, "Conflict");
            public static HTTPStatusCode Continue = new HTTPStatusCode(100, "Continue");
            public static HTTPStatusCode Created = new HTTPStatusCode(201, "Created");
            public static HTTPStatusCode ExpectationFailed = new HTTPStatusCode(417, "ExpectationFailed");
            public static HTTPStatusCode Forbidden = new HTTPStatusCode(403, "Forbidden");
            public static HTTPStatusCode Found = new HTTPStatusCode(302, "Found");
            public static HTTPStatusCode GatewayTimeout = new HTTPStatusCode(504, "GatewayTimeout");
            public static HTTPStatusCode Gone = new HTTPStatusCode(410, "Gone");
            public static HTTPStatusCode HttpVersionNotSupported = new HTTPStatusCode(505, "HttpVersionNotSupported");
            public static HTTPStatusCode InternalServerError = new HTTPStatusCode(500, "InternalServerError");
            public static HTTPStatusCode LengthRequired = new HTTPStatusCode(411, "LengthRequired");
            public static HTTPStatusCode MethodNotAllowed = new HTTPStatusCode(405, "MethodNotAllowed");
            public static HTTPStatusCode Moved = new HTTPStatusCode(301, "Moved");
            public static HTTPStatusCode MovedPermanently = new HTTPStatusCode(301, "MovedPermanently");
            public static HTTPStatusCode MultipleChoices = new HTTPStatusCode(300, "MultipleChoices");
            public static HTTPStatusCode NoContent = new HTTPStatusCode(204, "NoContent");
            public static HTTPStatusCode NonAuthoritativeInformation = new HTTPStatusCode(203, "NonAuthoritativeInformation");
            public static HTTPStatusCode NotAcceptable = new HTTPStatusCode(406, "NotAcceptable");
            public static HTTPStatusCode NotFound = new HTTPStatusCode(404, "NotFound");
            public static HTTPStatusCode NotImplemented = new HTTPStatusCode(501, "NotImplemented");
            public static HTTPStatusCode NotModified = new HTTPStatusCode(304, "NotModified");
            public static HTTPStatusCode OK = new HTTPStatusCode(200, "OK");
            public static HTTPStatusCode PartialContent = new HTTPStatusCode(206, "PartialContent");
            public static HTTPStatusCode PaymentRequired = new HTTPStatusCode(402, "PaymentRequired");
            public static HTTPStatusCode PreconditionFailed = new HTTPStatusCode(412, "PreconditionFailed");
            public static HTTPStatusCode ProxyAuthenticationRequired = new HTTPStatusCode(407, "ProxyAuthenticationRequired");
            public static HTTPStatusCode Redirect = new HTTPStatusCode(302, "Redirect");
            public static HTTPStatusCode RedirectKeepVerb = new HTTPStatusCode(307, "RedirectKeepVerb");
            public static HTTPStatusCode RedirectMethod = new HTTPStatusCode(303, "RedirectMethod");
            public static HTTPStatusCode RequestedRangeNotSatisfiable = new HTTPStatusCode(416, "RequestedRangeNotSatisfiable");
            public static HTTPStatusCode RequestEntityTooLarge = new HTTPStatusCode(413, "RequestEntityTooLarge");
            public static HTTPStatusCode RequestTimeout = new HTTPStatusCode(408, "RequestTimeout");
            public static HTTPStatusCode RequestUriTooLong = new HTTPStatusCode(414, "RequestUriTooLong");
            public static HTTPStatusCode ResetContent = new HTTPStatusCode(205, "ResetContent");
            public static HTTPStatusCode SeeOther = new HTTPStatusCode(303, "SeeOther");
            public static HTTPStatusCode ServiceUnavailable = new HTTPStatusCode(503, "ServiceUnavailable");
            public static HTTPStatusCode SwitchingProtocols = new HTTPStatusCode(101, "SwitchingProtocols");
            public static HTTPStatusCode TemporaryRedirect = new HTTPStatusCode(307, "TemporaryRedirect");
            public static HTTPStatusCode Unauthorized = new HTTPStatusCode(401, "Unauthorized");
            public static HTTPStatusCode UnsupportedMediaType = new HTTPStatusCode(415, "UnsupportedMediaType");
            public static HTTPStatusCode Unused = new HTTPStatusCode(306, "Unused");
            public static HTTPStatusCode UpgradeRequired = new HTTPStatusCode(426, "UpgradeRequired");
            public static HTTPStatusCode UseProxy = new HTTPStatusCode(305, "UseProxy");
            public static HTTPStatusCode ConnectionEstablished = new HTTPStatusCode(200, "Connection established");
        }
        public class KeyValuePair
        {
            public string Key;
            public object Value;
            public KeyValuePair(string key,object value)
            {
                Key = key;
                this.Value = value;
            }
            public override string ToString()
            {
                return Key + ":" + Value;
            }
        }
    }
    
}
