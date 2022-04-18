using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektLeg
{
    public class GameDTO
    {
        public GameDTO()
        {
            itemsID = new List<int>();
            enemyID = new List<int>();
            PuzzleID = new List<int>(); 
        }
        //User
        public string Username { get; set; }

        //Save
        public int RoomID { get; set; }

        public string SaveName { get; set; }

        public long? Health { get; set; }

        public int? Armour_ID { get; set; }

        public int? Weapon_ID { get; set; }


        //Inventory
        public List<int>? itemsID { get; set; }

        //Enemies
        public List<int>? enemyID { get; set; }

        //Puzzles
        public List<int>? PuzzleID { get; set; }



    }
}
