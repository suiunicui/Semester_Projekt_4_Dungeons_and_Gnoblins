using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models
{
    public class Puzzles
    {
        [Key]
        public int Puzzles_ID { get; set; }

        public int Save_ID { get; set; }

        public Save save { get; set; }
    }
}
