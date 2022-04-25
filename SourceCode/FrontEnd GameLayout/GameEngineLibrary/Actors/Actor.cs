using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineLibrary.Actors
{
    public abstract class Actor
    {
        public uint HP { get; set; }
        public uint AC { get; set; }

        public abstract uint Attack(Actor target);
    }
}
