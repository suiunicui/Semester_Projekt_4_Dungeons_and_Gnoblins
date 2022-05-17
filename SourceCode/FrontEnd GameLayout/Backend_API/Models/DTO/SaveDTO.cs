namespace Backend_API.Models.DTO
{
    public class SaveDTO
    {
<<<<<<< HEAD
        public int ID { get; set; }

        public int RoomId { get; set; }

        public string SaveName { get; set; }

        public string Username { get; set; }

        public List<uint> VisitedRooms { get; set; }
=======
        public SaveDTO()
        {
            Inventory = new List<uint>();
            SlainEnemies = new List<uint>();
            PuzzleID = new List<uint>();
            VisitedRooms = new List<uint>();
        }

        public int ID { get; set; }

        //User
        public string Username { get; set; }

        //Save
        public int RoomID { get; set; }

        public string SaveName { get; set; }

        public uint? Health { get; set; }

        public int? ShieldId { get; set; }

        public int? WeaponId { get; set; }


        //Inventory
        public List<uint>? SlainEnemies { get; set; }

        //Enemies
        public List<uint>? Inventory { get; set; }

        //Puzzles
        public List<uint>? PuzzleID { get; set; }

        public List<uint>? VisitedRooms { get; set; }
>>>>>>> FrontEnd
    }
}
