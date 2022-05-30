using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Abstract_Class
{
    public abstract class DiceRoller
    {
        public abstract uint RollDice(uint numOfSides);
        public virtual uint RollDice((uint numOfSides, uint numOfDice) damageDice, uint sum = 0) 
        {
            throw new NotImplementedException();
        }
        public virtual (uint, bool) RollDice(string diceRollExpression) 
        {
            throw new NotImplementedException();
        }
    }
}
