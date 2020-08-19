using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieHTTP.HTTPResolve
{
    public class ConnectionHeader:HTTPHeader
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
    public class KeepAliveHeader : HTTPHeader
    {
        protected string HeaderKey;
        protected List<KeyValuePair> HeaderValue;
        public KeepAliveHeader()
        {
            HeaderKey = "Keep-Alive";
            HeaderValue = new List<KeyValuePair>();
        }
        public KeepAliveHeader(string rawString)
        {
            HeaderKey = "Keep-Alive";
            CommonHeader cHeader = new CommonHeader(rawString);
            string[] paras = ((string)cHeader.Value).Split(',');
            foreach(string s in paras)
            {
                string res = "";
                bool flag = false;
                for(int i = 0; i < s.Length; i++)
                {
                    if (flag)
                    {
                        res += s[i];
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(s))
                        {

                        }
                        else
                        {
                            flag = true;
                            res += s[i];
                        }
                    }
                }
                string[] sPara = res.Split('=');
                HeaderValue.Add(new KeyValuePair(sPara[0], Convert.ToInt32(sPara[1])));
            }
        }
        public int MaxConnections
        {
            get
            {
                KeyValuePair max = this.FindValue("max");
                int maxCount = Convert.ToInt32((string)max.Value);
                return maxCount;
            }
            set
            {
                KeyValuePair max = this.FindValue("max");
                max.Value = value;
            }
        }
        public int Timeout
        {
            get
            {
                KeyValuePair t = this.FindValue("timeout");
                int timeout = Convert.ToInt32((string)t.Value);
                return timeout;
            }
            set
            {
                KeyValuePair t = this.FindValue("timeout");
                t.Value = value;
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
                HeaderValue =(List<KeyValuePair>) value;
            }
        }
        public override string GetValueString()
        {
            string result = "";
            for(int i = 0; i < HeaderValue.Count - 1; i++)
            {
                result += HeaderValue[i].ToString()+",";
            }
            result += HeaderValue[HeaderValue.Count - 1].ToString();
            return result;
        }
        public override string GetHeaderString()
        {
            return HeaderKey + ":" + GetValueString();
        }
        public KeyValuePair FindValue(string Key)
        {
            foreach(KeyValuePair p in HeaderValue)
            {
                if (p.Key == Key)
                {
                    return p;
                }
            }
            return null;
        }
        public void AddValue(KeyValuePair p)
        {
            HeaderValue.Add(p);
        }
        public void RemoveValue(string Key)
        {
            foreach (KeyValuePair p in HeaderValue)
            {
                if (p.Key == Key)
                {
                    HeaderValue.Remove(p);
                }
            }
        }
    }
}
