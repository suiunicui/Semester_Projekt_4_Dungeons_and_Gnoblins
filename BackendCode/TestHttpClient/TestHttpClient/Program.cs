
using TestHttpClient.Models;

namespace TestHttpClient
{
    class TestHttpClient
    {
        static void Main(string[] args)
        {
            var player = new Player
            {
      
                RoomId = 2,
            };

            var httpController = new HttpController("https://localhost:7046/api/Players");

            httpController.PostPlayer(player);

            httpController.GetPlayer();

            while (true)
            {

            }
        }
    }
}