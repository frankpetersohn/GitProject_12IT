using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PetersohnKlassenarbeit.Services
{
    internal class ApiService
    {
        public static string ApiUrl = "https://frankpetersohn.github.io/";
        public enum ApiOptions
        {
            berufe,
            lernfelder
        };

        public static async Task<string> GetServerResponseAsJson(string url)
        {
            string result = string.Empty;
            await Task.Run(() =>
            {
                try
                {                
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader reader = new(response.GetResponseStream());
                    result = reader.ReadToEnd();
                    //string json = reader.ReadToEnd();
                    //var result = JsonConvert.DeserializeObject(json).ToString();
                    //return (string)result;});
                }
                catch
                {
                    Console.WriteLine($"Antwort von '{url}' ungültig");
                    
                }
            });
            return result;

        }
    }
}
