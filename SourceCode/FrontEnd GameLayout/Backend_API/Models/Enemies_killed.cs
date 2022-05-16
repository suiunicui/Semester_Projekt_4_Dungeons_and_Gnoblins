using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models
{
    public class Enemies_killed
    {

        public uint EnemyID { get; set; }

        public int SaveID { get; set; }

        public Save save { get; set; }
    }
}
