namespace Backend_API.Models.DTO
{
    public class SaveDTO
    {
        public SaveDTO()
        {
            itemsID = new List<uint>();
            enemyID = new List<uint>();
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

        public int? Armour_ID { get; set; }

        public int? Weapon_ID { get; set; }


        //Inventory
        public List<uint>? itemsID { get; set; }

        //Enemies
        public List<uint>? enemyID { get; set; }

        //Puzzles
        public List<uint>? PuzzleID { get; set; }

        public List<uint>? VisitedRooms { get; set; }
    }
}
