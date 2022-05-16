namespace GameEngine.Models.DTO
{
    public class SaveDTO
    {
        public SaveDTO()
        {
            Inventory = new List<uint>();
            SlainEnemies = new List<uint>();
            PuzzleID = new List<uint>();
            VisitedRooms = new List<uint>();
        }

        public int ID { get; set; }

        public int RoomId { get; set; }

        public string SaveName { get; set; }

        public string Username { get; set; }

        public uint Health { get; set; }

        public List<uint> VisitedRooms { get; set; }
        public List<uint> Inventory { get; set; }
        public List<uint> SlainEnemies { get; set; }
        public List<uint>? PuzzleID { get; set; }

        public uint? ShieldId { get; set; }
        public uint? WeaponId { get; set; }
    }
}
