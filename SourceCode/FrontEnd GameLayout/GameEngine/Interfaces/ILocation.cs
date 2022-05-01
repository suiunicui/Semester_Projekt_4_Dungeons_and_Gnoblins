using GameEngine.Implementations;

namespace GameEngine.Interfaces;

public interface ILocation : IDescriptor
{
    public uint Id { get; set; }
    public Player Player { get; set; }
}