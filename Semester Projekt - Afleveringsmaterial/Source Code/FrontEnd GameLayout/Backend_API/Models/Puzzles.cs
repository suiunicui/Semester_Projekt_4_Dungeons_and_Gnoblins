using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models
{
    public class Puzzles
    {

        public uint Puzzles_ID { get; set; }

        public int Save_ID { get; set; }

        public Save save { get; set; }
    }
}
