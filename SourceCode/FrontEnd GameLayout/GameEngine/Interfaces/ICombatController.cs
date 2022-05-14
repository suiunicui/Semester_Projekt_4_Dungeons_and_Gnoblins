using GameEngine.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface ICombatController
    {
        public ILog EngageCombat(ref Player player, ref Enemy enemy);
        public void Flee();
    }
}