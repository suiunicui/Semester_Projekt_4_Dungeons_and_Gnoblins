using GameEngine.Implementations;

namespace GameEngine.Interfaces;

public enum Direction
{
    West,
    North,
    East,
    South
}

public interface IMap
{
    
    public ILocation[] Rooms { get; set; }
    public LinkedList<int>[] MapLayout { get; set; }
    public ILocation GetLocationByDirection(ILocation currentRoom, Direction dir);
}