using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Implementations
{
    public class Axe : Weapon
    {
        public Axe((uint numOfSides,uint numOfDice) damageDice, uint damage, uint hit)
        {
            ++ID;
            Id = ID;
            DamageDice = damageDice;
            Damage = damage;
            Hit = hit;
            ItemType = "Axe";
        }
    }
}
