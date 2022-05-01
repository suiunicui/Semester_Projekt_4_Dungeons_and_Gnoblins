using GameEngineLibrary.Interfaces;

namespace GameEngineLibrary.MapImpl;

public class Map : IMap
{
  public Room[] Rooms { get; private set; }
  public LinkedList<int>[] MapLayout { get; set; }
  public Map(IMapCreator mapCreator)
  {

    MapLayout = GenerateMapLayoutFromFile(mapCreator.FilePath);
    Rooms = GenerateRooms(mapCreator.FilePath);
  }

  private LinkedList<int>[] GenerateMapLayoutFromFile(string filePath)
  {
    LinkedList<int>[] mapLayout = CreateConnectionsBetweenRoomsFromLayoutFile(filePath);
    return mapLayout;
  }

  private LinkedList<int>[] CreateConnectionsBetweenRoomsFromLayoutFile(string filepath)
  {
    int mapSize = CalculateMapSize(filepath);
    LinkedList<int>[] connections = new LinkedList<int>[mapSize];

    StreamReader sr = new StreamReader(filepath);
    int index = 0;
    while (!sr.EndOfStream)
    {
      string linkingString = sr.ReadLine();
      connections[index++] = CreateRoomLink(linkingString);
    }
    sr.Close();
   
    return connections;
  }

  private LinkedList<int> CreateRoomLink(string linkingString)
  {
    int[] link = linkingString.Split(",").Select(int.Parse).ToArray();
    return new LinkedList<int>(link);
  }

  private int CalculateMapSize(string LayoutFilePath)
  {
    StreamReader sr = new StreamReader(LayoutFilePath);
    int mapSize = 0;
    while (!sr.EndOfStream)
    {
      sr.ReadLine();
      mapSize++;
    }
    sr.Close();
    return mapSize;
  }

  private Room[] GenerateRooms(string LayoutFilePath)
  {
    int mapSize = CalculateMapSize(LayoutFilePath);
    Room[] rooms = new Room[mapSize];

    for (int i = 0; i < mapSize; i++)
    {
      rooms[i] = new Room((uint) i);
    }
    return rooms;
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
          if (!isValidRoom(newRoomId)) return curRoom;
          newRoom = Rooms[newRoomId];
          break;
        case "north":
          newRoomId = MapLayout[curRoom.RoomId].ElementAt(1);
          if (!isValidRoom(newRoomId)) return curRoom;
          newRoom = Rooms[newRoomId];
          break;
        case "east":
          newRoomId = MapLayout[curRoom.RoomId].ElementAt(2);
          if (!isValidRoom(newRoomId)) return curRoom;
          newRoom = Rooms[newRoomId];
          break;
        case "south":
          newRoomId = MapLayout[curRoom.RoomId].ElementAt(3);
          if (!isValidRoom(newRoomId)) return curRoom;
          newRoom = Rooms[newRoomId];
          break;
        default:
          break;
      }

      return newRoom;
    }

  private bool isValidRoom(int roomId)
  {
    return roomId > 0;
  }
}
