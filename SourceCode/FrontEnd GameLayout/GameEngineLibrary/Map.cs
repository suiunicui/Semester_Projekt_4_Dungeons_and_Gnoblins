using System.Xml.Serialization;

namespace GameEngineLibrary;

public class Map
{
  private LinkedList<Room>[] _mapLayout;

  public Map(int numOfRooms)
  {
    _mapLayout = new LinkedList<Room>[numOfRooms];
    PopulateMapLayout(numOfRooms);
  }

  private void PopulateMapLayout(int numOfRooms)
  {
    if (numOfRooms == 0)
    {
      return;
    }

    _mapLayout[--numOfRooms].AddFirst(new Room());
    PopulateMapLayout(--numOfRooms);
    return;
  }

  public Room GetRoom(int RoomId)
  {
    return _mapLayout[RoomId].First.Value;
  }
}