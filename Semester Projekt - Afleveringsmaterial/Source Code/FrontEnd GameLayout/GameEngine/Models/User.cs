using System.ComponentModel.DataAnnotations;

namespace GameEngine.Models
{
    public class User
    {
        public long UserId { get; set; }

        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }

        public List<Save> Saves { get; set; }

    }
}
