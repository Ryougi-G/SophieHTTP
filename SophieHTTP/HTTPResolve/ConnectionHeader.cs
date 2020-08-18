using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP.HTTPResolve
{
    class ConnectionHeader:HTTPHeader
    {
        protected string HeaderKey;
        protected List<string> HeaderValue;
        public ConnectionHeader()
        {
            HeaderKey = "Connection";
            HeaderValue = new List<string>();
        }
        public ConnectionHeader(List<string> Content)
        {
            HeaderKey = "Connection";
            HeaderValue = Content;
        }
        public ConnectionHeader(CommonHeader header)
        {
            HeaderKey = "Connection";
            string[] rawValue = header.GetValueString().Split(',');
            HeaderValue = new List<string>();
            foreach(string s in rawValue)
            {
                HeaderValue.Add(s);
            }
        }
        public ConnectionHeader(string rawHeader)
        {
            CommonHeader header = new CommonHeader(rawHeader);
            HeaderKey = "Connection";
            string[] rawValue = header.GetValueString().Split(',');
            HeaderValue = new List<string>();
            foreach (string s in rawValue)
            {
                HeaderValue.Add(s);
            }
        }
        public override string Key {
            get
            {
                return HeaderKey;
            }
            set
            {
                
            }
        }
        public override object Value {
            get
            {
                return HeaderValue;
            }
            set
            {
                HeaderValue = (List<string>)value;
            }
        }
        public string FindValue(string value)
        {
            foreach (string s in HeaderValue)
            {
                if (s == value)
                {
                    return s;
                }
            }
            return null;
        }
        public void AddValue(string value)
        {
            HeaderValue.Add(value);
        }
        public void RemoveValue(string value)
        {
            HeaderValue.Remove(value);
        }
        public override string GetValueString()
        {
            string result = "";
            for(int i = 0; i < HeaderValue.Count-1; i++)
            {
                result += HeaderValue[i] + ",";
            }
            result += HeaderValue[HeaderValue.Count - 1];
            return result;
        }
        public override string GetHeaderString()
        {
            return HeaderKey + ":" + this.GetValueString();
        }
    }
}
