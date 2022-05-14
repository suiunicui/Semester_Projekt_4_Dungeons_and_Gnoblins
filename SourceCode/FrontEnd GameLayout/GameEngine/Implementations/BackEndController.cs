using System.Text;
using System.Text.Json;
using GameEngine.Models.DTO;
using GameEngine.Interfaces;
using Backend_API.Models;
using System.Net.Http.Headers;

namespace GameEngine.Implementations;

public class BackEndController : IBackEndController
 {
    private string _url;

    private RoomDescription _roomDescription;
    private readonly HttpClient _httpClient;
    private SaveDTO _save;
    public Token token;

    private static volatile BackEndController instance;

    public BackEndController()
    {
        _httpClient = new HttpClient();
        //_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.JWT);
        
    }

    public static BackEndController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BackEndController();
            }
            return instance;
        }
    }

    public async Task<SaveDTO>GetSaveAsync(int id)
    {
        _url = $"https://localhost:7046/api/Save?id={id}";
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.JWT);
        try
        {
            string responsBody = await _httpClient.GetStringAsync(_url);
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

    public async Task<RoomDescription> GetRoomDescriptionAsync(int id)
    {
        _url = $"https://localhost:7046/api/Save/Get_Room_Description?id={id}";
        try
        {
            string responsBody = await _httpClient.GetStringAsync(_url);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,

            };

            _roomDescription = JsonSerializer.Deserialize<RoomDescription>(responsBody, options);


        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Exception caught");
            Console.WriteLine("Message: {0}", e.Message);
            throw;
        }

        return _roomDescription;
    }

    public async Task<List<SaveDTO>> GetListOfSave()
    {
        List<SaveDTO> _savelist;
        _url = $"https://localhost:7046/api/Save/Get List Of Saves";
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.JWT);
        try
        {
            
            string responsBody = await _httpClient.GetStringAsync(_url);
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

    public async Task PostSaveAsync(SaveDTO save)
    {
        _url = "https://localhost:7046/api/Save";
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.JWT);

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
    public async Task PostRegisterAsync(UserDTO user)
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


