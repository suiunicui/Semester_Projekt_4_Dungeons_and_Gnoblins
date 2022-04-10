using System.Collections;
using System.Resources;

namespace GameEngineLibrary
{
  public class Map
  {
    public List<Room> Rooms { get; set; } = new List<Room>();
    public LinkedList<int>[] MapLayout { get; set; }
    private readonly string _mapLayoutResource = Environment.CurrentDirectory + "\\Resource.txt";

    public Map(int numOfRooms)
    {
      MapLayout = new LinkedList<int>[numOfRooms];
      CreateConnectionsBetweenRoomsFromMapLayoutFile();
    }

    private void CreateConnectionsBetweenRoomsFromMapLayoutFile()
    {
      ResourceReader reader = new ResourceReader(_mapLayoutResource);
      CreateConnectionsBetweenRooms(reader);
      reader.Close();
    }

    private void CreateConnectionsBetweenRooms(ResourceReader reader)
    {
      int index = 0;
      foreach (DictionaryEntry entry in reader)
      {
        MapLayout[index++] = CreateConnection(entry);
      }

      MapLayout = MapLayout.Reverse().ToArray();
    }

    private LinkedList<int> CreateConnection(DictionaryEntry entry)
    {
      int[] connections = entry.Value.ToString()
                                     .Split(",")
                                     .Select(line => int.Parse(line))
                                     .ToArray();
      
      return new LinkedList<int>(connections);
    }
  }
}
