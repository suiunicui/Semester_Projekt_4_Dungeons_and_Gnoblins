namespace GameEngineLibrary.Interfaces;

public interface IMap
{
  public Room GetRoomByDirection(Room curRoom, string direction);
}