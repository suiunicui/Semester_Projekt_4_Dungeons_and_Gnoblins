using System.Text;
using System.Text.Json;
using Backend_API.Models.DTO;
using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class BackEndController : IBackEndController
 {
        public string _urlPostSave;
        public string _urlGetSave;
        private readonly HttpClient _httpClient;
        private SaveDTO _save;

        public BackEndController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<SaveDTO>GetSaveAsync(int id)
        {
            _urlGetSave = $"https://localhost:7046/api/Save?id={id}";
            try
            {
                string responsBody = await _httpClient.GetStringAsync(_urlGetSave);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,

                };

                _save = JsonSerializer.Deserialize<SaveDTO>(responsBody, options);
          
                Console.WriteLine("RoomId: {0}", _save.RoomId);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught");
                Console.WriteLine("Message: {0}", e.Message);
                throw;
            }

            return _save;
        }

    public async Task<List<SaveDTO>> GetListOfSave()
    {
        List<SaveDTO> _savelist;
        _urlGetSave = $"https://localhost:7046/api/Save/Get List Of Saves";
        try
        {
            string responsBody = await _httpClient.GetStringAsync(_urlGetSave);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,

            };

            _savelist = JsonSerializer.Deserialize<List<SaveDTO>>(responsBody, options);

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Exception caught");
            Console.WriteLine("Message: {0}", e.Message);
            throw;
        }

        return _savelist;
    }

    public async void PostSaveAsync(SaveDTO save)
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
