using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Abstract_Class
{
    public class Shield : Item
    {
        public uint AC { get; set; }
        public Shield(uint armorClass)
        {
            AC = armorClass;
            ItemType = "Shield";
        }
    }
}
