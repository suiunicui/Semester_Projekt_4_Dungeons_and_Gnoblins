using System.Collections;
using System.Resources;

namespace GameEngineLibrary
{
  public class Maps
  {
    public Room[] Rooms { get; set; }
    public LinkedList<int>[] MapLayout { get; set; }
    private readonly string _mapLayoutResource = Path.GetFullPath(Environment.CurrentDirectory + @"\\Resource.resources");

    public Maps()
    {
      MapLayout = CalculateLinkedListSizeFromMapLayoutFile();
      // CreateConnectionsBetweenRoomsFromMapLayoutFile();
      Rooms = new Room[20];

      int i = 0;
      foreach (Room room in Rooms)
      {
        Rooms[i] = new Room((uint) i);
        i++;
      }

    }

    public Room GetRoomByDirection(Room curRoom, string direction)
    {
      string dir = direction.ToLower();
      Room newRoom = null;
      int newRoomId;
      switch (dir)
      {
        case "west":
          newRoomId = MapLayout[curRoom.RoomId].ElementAt(0);
          newRoom = Rooms[newRoomId];
          break;
        case "north":
          newRoomId = MapLayout[curRoom.RoomId].ElementAt(1);
          newRoom = Rooms[newRoomId];
          break;
        case "east":
          newRoomId = MapLayout[curRoom.RoomId].ElementAt(2);
          newRoom = Rooms[newRoomId];
          break;
        case "south":
          newRoomId = MapLayout[curRoom.RoomId].ElementAt(3);
          newRoom = Rooms[newRoomId];
          break;
        default:
          break;
      }

      return newRoom;
    }

    private string convertMapLayout(string mapLayoutPath)
    {
      StreamReader sr = new StreamReader(mapLayoutPath);
      string newFilePath = Environment.CurrentDirectory + @"\\newResource.resources";
      ResourceWriter rw = new ResourceWriter(newFilePath);

      int i = 0;
      while (!sr.EndOfStream)
      {
        rw.AddResource((i++).ToString(), sr.ReadLine());
      }
      rw.Close();
      sr.Close();

      return newFilePath;
    }

    private LinkedList<int>[] CalculateLinkedListSizeFromMapLayoutFile()
    {
      string _convertedFileType = convertMapLayout(_mapLayoutResource);
      ResourceReader reader = new ResourceReader(_convertedFileType);
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
      string convetedFilePath = convertMapLayout(_mapLayoutResource);
      ResourceReader reader = new ResourceReader(convetedFilePath);
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
      int indexOfEqual = entry.Value.ToString().IndexOf("=") + 1;
      string connectionString = entry.Value.ToString().Remove(0, indexOfEqual);
      int[] connectionArray = connectionString.Split(",").Select(c => c=="" ? -1 : int.Parse(c)).ToArray();
      return new LinkedList<int>(connectionArray.Where(r => r != -1));
    }
  }
}
