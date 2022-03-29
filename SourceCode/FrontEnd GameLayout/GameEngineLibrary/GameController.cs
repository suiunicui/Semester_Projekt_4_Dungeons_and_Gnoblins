using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineLibrary
{

    public class GameController : Descriptor
    {
        public Map GameMap { get; set; }
        public GameController() { }


        public string Move(string direction)
        {
            return direction;
        }
    }
}
