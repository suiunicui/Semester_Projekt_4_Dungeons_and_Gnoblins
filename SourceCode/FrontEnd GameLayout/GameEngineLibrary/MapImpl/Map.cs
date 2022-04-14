using System.Collections;
using System.Collections.Immutable;
using System.Resources;
using GameEngineLibrary.Interfaces;

namespace GameEngineLibrary.MapImpl;

public class Map : IMap
{
  public Room[] Rooms { get; private set; } = new Room[19];
  public LinkedList<int>[] MapLayout { get; set; }
  public Map(IMapCreator mapCreator)
  {
    MapLayout = GenerateMapLayoutFromFile(mapCreator.FilePath);
    int index = 0;
    foreach (var room in Rooms)
    {
      Rooms[index] = new Room((uint) index);
      index++;
    }
  }

  private LinkedList<int>[] GenerateMapLayoutFromFile(string filePath)
  {
    LinkedList<int>[] mapLayout = CreateConnectionsBetweenRoomsFromLayoutFile(filePath);
    return mapLayout;
  }

  private LinkedList<int>[] CreateConnectionsBetweenRoomsFromLayoutFile(string filepath)
  {
    StreamReader sr = new StreamReader(filepath);
    LinkedList<int>[] connections = new LinkedList<int>[19];
    int index = 0;
    while (!sr.EndOfStream)
    {
      int[] con = sr.ReadLine().Split(",").Select(int.Parse).ToArray();
      connections[index++] = new LinkedList<int>(con);
    }
    sr.Close();
   
    return connections;
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
}