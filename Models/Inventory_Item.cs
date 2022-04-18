using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ProjektLeg.Models
{
    public class Inventory_Items
    {
       
        public int ItemID { get; set; }

        public int SaveID  { get; set; }

        public Save save { get; set; }
    }

}
