using System.ComponentModel.DataAnnotations;

namespace TestHttpClient.Models
{
    public class UserDTO
    {
        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }
    }
}
