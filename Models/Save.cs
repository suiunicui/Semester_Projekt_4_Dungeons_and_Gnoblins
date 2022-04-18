using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjektLeg.Models
{
    public class Save
    {
        [Key]
        [Required]
        public int SaveID   { get; set; }

        public string SaveName { get; set; }

        public int RoomID { get; set; }

        public long? Health { get; set; }

        public int? Armour_ID { get; set; }

        public int? Weapon_ID { get; set; }

        public string name { get; set; }

        public User user { get; set; }

        public List<Puzzles> Save_Puzzles { get; set; }

        public List<Inventory_Items> Save_Inventory_Items { get; set; }

        public List<Enemies_killed> Save_Enemies_killed { get; set; }

    }
}
