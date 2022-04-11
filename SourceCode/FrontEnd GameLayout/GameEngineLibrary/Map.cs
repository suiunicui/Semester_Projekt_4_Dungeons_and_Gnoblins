using System.Collections;
using System.Resources;

namespace GameEngineLibrary
{
  public class Map
  {
    public List<Room> Rooms { get; set; } = new List<Room>();
    public LinkedList<int>[] MapLayout { get; set; }
    private readonly string _mapLayoutResource = Path.GetFullPath(Environment.CurrentDirectory + @"\\Resource.txt");

    public Map()
    {
      MapLayout = CalculateLinkedListSizeFromMapLayoutFile();
      CreateConnectionsBetweenRoomsFromMapLayoutFile();
    }

    public Room GetRoomByDirection(Room curRoom, string direction)
    {
      string dir = direction.ToLower();
      Room newRoom = null;
      int newRoomId;
      switch (dir)
      {
        case "west":
          newRoomId = MapLayout[curRoom.RoomId].First.Value;
          newRoom = Rooms[newRoomId];
          break;
        case "north":
          newRoomId = MapLayout[curRoom.RoomId].First.Next.Value;
          newRoom = Rooms[newRoomId];
          break;
        case "east":
          newRoomId = MapLayout[curRoom.RoomId].First.Next.Next.Value;
          newRoom = Rooms[newRoomId];
          break;
        case "south":
          newRoomId = MapLayout[curRoom.RoomId].First.Next.Next.Next.Value;
          newRoom = Rooms[newRoomId];
          break;
        default:
          break;

      }

      return newRoom;
    }

    private LinkedList<int>[] CalculateLinkedListSizeFromMapLayoutFile()
    {
      ResourceReader reader = new ResourceReader(_mapLayoutResource);
      int MapLayoutSize = CalculateMapLayoutSize(reader);
      reader.Close();

      return new LinkedList<int>[MapLayoutSize];
    }

    private int CalculateMapLayoutSize(ResourceReader reader)
    {
      int MapLayoutSize = 0;
      foreach (DictionaryEntry entry in reader)
      {
        MapLayoutSize++;
      }
      return MapLayoutSize;
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
