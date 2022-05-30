using System.ComponentModel;
using GameEngine.Interfaces;

namespace GameEngine.Actors;

public abstract class Actor : IDescriptor
{
   private static uint ID = 0;
   public uint HP { get; set; }
   public virtual uint AC { get; set; }
   public string Description { get; set; }

}
