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

        public static string GetApiResponse(string url)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
            };
            var response = client.SendAsync(request).Result;

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
