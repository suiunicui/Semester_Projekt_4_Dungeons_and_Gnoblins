using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Abstract_Class
{
    public abstract class Item
    {
        protected static uint ID = 0;
        public uint Id { get; set; }

    }
}
