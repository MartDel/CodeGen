using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace CodeGen
{
    public class API
    {
        private JToken security = JToken.Parse(Encoding.ASCII.GetString(Properties.Resources.tokens));
        private string token;
        public Uri Url;
        
        public API(Uri url)
        {
            string name = url.Host;

            JObject tokens = security.Value<JObject>("tokens");
            string token_encode = tokens.Value<string>(name);
            string token = decode(token_encode);
            this.token = token;
            
            Url = url;
        }
        
        public string GetRequest(string url, bool withBaseUrl)
        {
            string final_url;
            if (withBaseUrl) { final_url = Url.AbsoluteUri + url; }
            else { final_url = url; }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(final_url);
            request.Timeout = 10000;
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json";
            request.UserAgent = "martdel";
            request.Headers.Add("Authorization", "Bearer " + token);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string result = reader.ReadToEnd();
            response.Close();
            reader.Close();
            return result;
        }

        private string decode(string text)
        {
            // Get key
            string key = security.Value<string>("key");

            byte[] txtToBytes = Convert.FromBase64String(text);
            byte[] keyToBytes = Encoding.UTF8.GetBytes(key);
            DESCryptoServiceProvider crypto = new DESCryptoServiceProvider();
            crypto.Key = keyToBytes;
            crypto.IV = keyToBytes;
            ICryptoTransform Icrypto = crypto.CreateDecryptor();
            byte[] resultBytes = Icrypto.TransformFinalBlock(txtToBytes, 0, txtToBytes.Length);
            return Encoding.UTF8.GetString(resultBytes);
        }
    }
}
