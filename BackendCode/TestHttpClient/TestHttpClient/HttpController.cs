using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestHttpClient.Models;

namespace TestHttpClient
{
    internal class HttpController
    {
        private readonly string _url;
        private readonly HttpClient _httpClient;
        private readonly List<Save> _save;

        public HttpController(string url)
        {
            _url = url;
            
            _httpClient = new HttpClient();
            
            _save = new List<Save>();
        }
        public async void GetPlayer()
        {
            try
            {
                string responsBody = await _httpClient.GetStringAsync(_url);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var _save = JsonSerializer.Deserialize<List<Save>>(responsBody, options);
                foreach (var save in _save)
                {
                    Console.WriteLine("RoomId: {0}", save.RoomId);

                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught");
                Console.WriteLine("Message: {0}", e.Message);
                throw;
            }
        }

        public async void PostPlayer(Save save)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, _url))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(save, options);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    using (var response = await _httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
        }
    }
}
