
using TestHttpClient.Models;

namespace TestHttpClient
{
    class TestHttpClient
    {
        static void Main(string[] args)
        {
            var user = new UserDTO
            {
                Username = "4567891",
                Password = "567"
     
            };

            var httpController = new HttpController();

            httpController.PostLoginAsync(user);

            while (true)
            {

            }
        }
    }
}