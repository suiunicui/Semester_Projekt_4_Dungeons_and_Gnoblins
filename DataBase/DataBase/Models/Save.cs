using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DataBase.Models
{
    public class Save
    {
        [Key]
        [Required]
        public int ID { get; set; }

        public int RoomID { get; set; }

        //[Required]
        //public long Health { get; set; }

        //public int Armour_ID { get; set; }

        //public int Weapon_ID { get; set; }

        //[Required]
        //public int Room_ID { get; set; }

        //public List<Puzzles> Save_Puzzles { get; set; }

        //public List<Inventory_Items> Save_Inventory_Items { get; set; }

        //public List<Enemies_killed> Save_Enemies_killed { get; set; }


        

       

    }
}
