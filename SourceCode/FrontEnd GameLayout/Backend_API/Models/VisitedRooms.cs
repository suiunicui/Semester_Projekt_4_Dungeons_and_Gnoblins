namespace Backend_API.Models
{
    public class VisitedRooms
    {
        public uint VistedRoomId { get; set; }

        public int SaveId { get; set; }

        public Save Save { get; set; }
    }
}
