namespace Backend_API.Models.DTO
{
    public class GameDTO
    {

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

        public List<uint>? VisitedRooms { get; set; }


    }
}
