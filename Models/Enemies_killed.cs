using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProjektLeg.Models
{
    public class Enemies_killed
    {
        [Key]
        public int EnemyID { get; set; }

        public int SaveID { get; set; }

        public Save save { get; set; }
    }
}
