using GameEngine.Abstract_Class;
using GameEngine.Implementations;

namespace GameEngine.Interfaces;

public interface IGameController
{
    IMap GameMap { get; set; }
    ILocation CurrentLocation { get; set; }
    Player CurrentPlayer { get; set; }
    List<uint> VisitedRooms { get; set; }
    List<uint> SlainEnemies { get; set; }
    List<uint> Inventory { get; set; }
    ILog Move(Direction dir);
    Task SaveGame(int id, string savename);
    Task LoadGame(int id);
    Task GetRoomDescriptionAsync();
    public void EliminateEnemy();
    public void PickUpItem(Item item);

}

