using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ServiceClient
{
    public class Client
    {
        private readonly string _server;
        private string _url;

        public string Server => _server;
        public string Route { get; set; }
        
        public Client(string route)
        {
            Route = route;
            _server = ConfigurationManager.AppSettings.Get("WEB_API_SERVER");            
        }       
       

        public T Get<T>()
        {
            T obj = default(T);

            _url = string.Concat(_server, Route);
            HttpWebRequest request = WebRequest.CreateHttp(_url);

            request.ContentType = "application/json";
            request.MediaType = "application/json";
            request.Method = "GET";
            var response = request.GetResponse() as HttpWebResponse;
            if (response == null) return default(T);
            var resp = string.Empty;
            // ReSharper disable once AssignNullToNotNullAttribute
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                resp += reader.ReadToEnd();
            }
            obj = JsonConvert.DeserializeObject<T>(resp);

            return obj;
        }

        public T Get<T>(Dictionary<string, object> parameters)
        {
            T obj = default(T);
            bool first = true;
            var stringParameter = new StringBuilder();
            
            foreach (var parameter in parameters)
            {               
                stringParameter.Append(first ? "?" : "&");
                stringParameter.Append(Uri.EscapeUriString(parameter.Key));
                stringParameter.Append("=");
                if (parameter.Value != null)
                    stringParameter.Append(Uri.EscapeDataString(parameter.Value.ToString()));
                first = false;                
            }
            _url = string.Concat(_server, Route, stringParameter);
            
            HttpWebRequest request = WebRequest.CreateHttp(_url);

            request.ContentType = "application/json";
            request.MediaType = "application/json";
            request.Method = "GET";
            var response = request.GetResponse() as HttpWebResponse;
            if (response == null) return default(T);
            var resp = string.Empty;
            
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                resp += reader.ReadToEnd();
            }
            obj = JsonConvert.DeserializeObject<T>(resp);

            return obj;            
        }

        public T GeneralReques<T>(object requestData, string method)
        {
            T obj = default(T);
            _url = string.Concat(_server, Route);

            HttpWebRequest request = WebRequest.CreateHttp(_url);

            request.ContentType = "application/json";

            request.Method = method;
            if (requestData != null)
            {
                string serialized = JsonConvert.SerializeObject(requestData);
                byte[] content = Encoding.UTF8.GetBytes(serialized);
                request.ContentLength = content.Length;
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    char[] bytes = Encoding.UTF8.GetChars(content);
                    streamWriter.Write(bytes, 0, bytes.Length);
                    streamWriter.Close();
                }
            }
            var response = request.GetResponse() as HttpWebResponse;
            if (response == null) return default(T);
            var resp = string.Empty;
            
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                resp += reader.ReadToEnd();
            }
            obj = JsonConvert.DeserializeObject<T>(resp);

            return obj;
        }
    }
}
