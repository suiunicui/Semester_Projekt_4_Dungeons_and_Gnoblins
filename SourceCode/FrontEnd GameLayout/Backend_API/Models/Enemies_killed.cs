using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models
{
    public class Enemies_killed
    {
        [Key]
        public int EnemyID { get; set; }

        public int SaveID { get; set; }

        public Save save { get; set; }
    }
}
