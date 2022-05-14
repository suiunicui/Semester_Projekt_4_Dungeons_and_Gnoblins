using TestHttpClient;
using TestHttpClient.Models;

//namespace TestHttpClient
{
    //class TestHttpClient
    {
        //static void Main(string[] args)
        {
            var user = new UserDTO
            {
                Username = "Gamer2",
                Password = "123"
     
            };

            var httpController = new HttpController();

            await httpController.PostLoginAsync(user);

            var save = new List<Save>();

            save = await httpController.GetListOfSave();

            foreach (var item in save)
            {
                Console.WriteLine(item.Username);
            }



            while (true)
            {

            }
        }
    }
}