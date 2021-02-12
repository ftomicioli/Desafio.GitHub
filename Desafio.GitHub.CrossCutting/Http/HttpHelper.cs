using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Desafio.GitHub.CrossCutting.Http
{
    public static class HttpHelper<T>
    {
        public static T HttpRequest(string url, object parameters = null, string method = CustomHttpVerbs.Post)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            
            request.UserAgent = "TestApp"; //https://stackoverflow.com/questions/28781345/listing-all-repositories-using-github-c-sharp

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var content1 = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<T>(content1);
            }
        }

        public static T Http(string url, object parameters = null, string method = CustomHttpVerbs.Post)
        {
            var encoding = new UTF8Encoding(false);
            var webRequest = WebRequest.Create(url);
            webRequest.Timeout = 900000;
            webRequest.Method = method;
            webRequest.ContentType = "application/json";

            if (parameters != null)
            {
                var data = encoding.GetBytes(JsonConvert.SerializeObject(parameters));
                webRequest.ContentLength = data.Length;

                using (Stream requestStream = webRequest.GetRequestStream())
                    requestStream.Write(data, 0, data.Length);
            }

            using (WebResponse webResponse = webRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                    return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
            }
        }
    }
    public static class CustomHttpVerbs
    {
        public const string Get = "GET";
        public const string Head = "HEAD";
        public const string Post = "POST";
        public const string Put = "PUT";
        public const string Delete = "DELETE";
        public const string Connect = "CONNECT";
        public const string Options = "OPTIONS";
        public const string Trace = "TRACE";
        public const string Patch = "PATCH";
    }
}
