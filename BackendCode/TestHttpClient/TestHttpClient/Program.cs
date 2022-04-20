
using TestHttpClient.Models;

namespace TestHttpClient
{
    class TestHttpClient
    {
        static void Main(string[] args)
        {
            var save = new Save
            {
                RoomId = 24,
            };

            var httpController = new HttpController();

            //httpController.PostPlayer(save);

            httpController.GetPlayer(1);

            while (true)
            {

            }
        }
    }
}