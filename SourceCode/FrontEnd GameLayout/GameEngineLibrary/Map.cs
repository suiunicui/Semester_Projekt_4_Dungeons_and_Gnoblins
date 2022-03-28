using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineLibary
{
    public class Map : Descriptor
    {
        public Map()
        {
            LinkedList<Room> sentence = new LinkedList<Room>();
        for(int i = 0; i < 20; i++)
            {
             sentence.AddLast(new Room (i));
            }

        }

    }
}

#region Properties
public

#endregion

#region Methods



#endregion