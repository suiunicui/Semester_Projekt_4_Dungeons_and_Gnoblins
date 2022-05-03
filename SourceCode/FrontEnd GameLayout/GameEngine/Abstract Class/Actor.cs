using System.ComponentModel;
using GameEngine.Interfaces;

namespace GameEngine.Actors;

public abstract class Actor : IDescriptor
{
   public uint HP { get; set; }
   public uint AC { get; set; }
   public string Description { get; set; }
}
