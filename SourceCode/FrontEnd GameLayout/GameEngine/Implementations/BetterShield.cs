using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementations
{
    public class BetterShield : Shield
    {
        public uint AC { get; set; }
        public BetterShield(uint armorClass):base(armorClass)
        {
            ++ID;
            Id = ID;
            ++AC;
            ItemType = "Shield+1";
        }
    }
}
