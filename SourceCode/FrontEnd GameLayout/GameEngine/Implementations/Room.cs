using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class Room : ILocation
{
    public Room(uint roomId)
    {
        Id = roomId;
    }


    public string Description { get; set; } = "";
    public uint Id { get; set; }
}