
using TestHttpClient.Models;

namespace TestHttpClient
{
    class TestHttpClient
    {
        static void Main(string[] args)
        {
            var save = new Save
            {
      
                RoomId = 2,
            };

            var httpController = new HttpController("https://localhost:7046/api/Players");

            httpController.PostPlayer(save);

            httpController.GetPlayer();

            while (true)
            {

            }
        }
    }
}