using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ProjektLeg.Models
{
    public class Puzzles
    {
        [Key]
        public int Puzzles_ID { get; set; }

        public int Save_ID { get; set; }

        public Save save { get; set; }

    }

}
