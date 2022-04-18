using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Backend_API.Models.DTO;
using System.Net.Http.Json;

namespace WepApiTest
{
    public class UnitTest
    {
        SaveDTO player;
        public UnitTest()
        {
            player.RoomId = 1;
        }

        //[Theory]
        //[InlineData()]
        
        public async Task PostPlayerSucess(SaveDTO playerDTO)
        {
            var app = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(webHostBuilder => { });
            var client = app.CreateClient();
            var body = JsonContent.Create(new { value = playerDTO});
            var response = await client.PostAsync("/api/Players", body);
            response.EnsureSuccessStatusCode();

            Assert.Equal(playerDTO.ToString(), await response.Content.ReadAsStringAsync());
           
        }
    }
}