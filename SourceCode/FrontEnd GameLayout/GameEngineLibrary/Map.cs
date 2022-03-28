using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineLibrary
{
    public class Map
    {
        public List<Room> Rooms { get; set; }
        public LinkedList<int>[] MapLayout { get; set; }
        public int CurrentRoomId;

        public Map()
        {
            int i = 0;
            // missing file path
            foreach(string line in System.IO.File.ReadLines())
            {
                string[] lines = line.Split(",");
                int[] roomConnections = lines.Select(x => x == "" ? 0 : int.Parse(x)).ToArray();

                MapLayout[i++] = new LinkedList<int>(roomConnections);
            }
        }
    }
}
