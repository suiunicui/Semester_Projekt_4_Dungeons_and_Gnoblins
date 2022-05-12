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

        private string _url;
        private readonly HttpClient _httpClient;
        private readonly Save _save;
        public Token token;

        public HttpController()
        {

            _httpClient = new HttpClient();
            
        }
        public async void GetPlayer(int id)
        {
            _url = $"https://localhost:7046/api/Save?id={id}";
            try
            {
                string responsBody = await _httpClient.GetStringAsync(_url);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,

                };

                var _save = JsonSerializer.Deserialize<Save>(responsBody, options);
          
                Console.WriteLine("RoomId: {0}", _save.RoomID);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught");
                Console.WriteLine("Message: {0}", e.Message);
                throw;
            }
        }

        public async Task<List<Save>> GetListOfSave()
        {
            List<Save> _savelist;
            _url = $"https://localhost:7046/api/Save/Get List Of Saves";
            try
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.JWT);
                string responsBody = await _httpClient.GetStringAsync(_url);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,


                };

                _savelist = JsonSerializer.Deserialize<List<Save>>(responsBody, options);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught");
                Console.WriteLine("Message: {0}", e.Message);
                throw;
            }

            return _savelist;
        }

        public async void PostPlayer(Save save)
        {
            _url = "https://localhost:7046/api/Save";

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

        public async void PostRegisterAsync(UserDTO user)
        {
            var _url = "https://localhost:7046/api/User/Register";

            using (var request = new HttpRequestMessage(HttpMethod.Post, _url))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(user, options);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    using (var response = await _httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))

                    {
                        response.EnsureSuccessStatusCode();

                        var responseContent = await response.Content.ReadAsStringAsync();
                        var jsonOptions = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,

                        };

                        token = JsonSerializer.Deserialize<Token>(responseContent, options);

                        Console.WriteLine(token.JWT);
                    }

                }

            }
        }

        public async Task PostLoginAsync(UserDTO user)
        {
            var _url = "https://localhost:7046/api/User/Login";

            using (var request = new HttpRequestMessage(HttpMethod.Post, _url))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(user, options);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    using (var response = await _httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))

                    {
                        response.EnsureSuccessStatusCode();

                        var responseContent = await response.Content.ReadAsStringAsync();
                        var jsonOptions = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,

                        };

                        token = JsonSerializer.Deserialize<Token>(responseContent, options);

                        Console.WriteLine(token.JWT);
                    }

                }

            }
        }
    }
}
