using System.Text;
using System.Text.Json;
using DataBase.Models;
using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class BackEndController : IBackEndController
 {
        public string _urlPostSave;
        public string _urlGetSave;
        private readonly HttpClient _httpClient;
        private readonly Save _save;

        public BackEndController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Save>GetSaveAsync(int id)
        {
            _urlGetSave = $"https://localhost:7046/api/Save?id={id}";
            try
            {
                string responsBody = await _httpClient.GetStringAsync(_urlGetSave);
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

            return _save;
        }

        public async void PostSaveAsync(Save save)
        {
            _urlPostSave = "https://localhost:7046/api/Save";

            using (var request = new HttpRequestMessage(HttpMethod.Post, _urlPostSave))
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
