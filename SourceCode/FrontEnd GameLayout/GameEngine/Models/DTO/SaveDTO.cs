namespace GameEngine.Models.DTO
{
    public class SaveDTO
    {
        public int ID { get; set; }

        public int RoomId { get; set; }

        public string SaveName { get; set; }

        public string Username { get; set; }

        public List<uint> VisitedRooms { get; set; }
    }
}
