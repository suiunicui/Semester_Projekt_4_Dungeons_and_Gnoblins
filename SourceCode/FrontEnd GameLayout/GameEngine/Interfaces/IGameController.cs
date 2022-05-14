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
    void EliminateEnemy();
    void PickUpItem(Item item);
    ICombatController CombatController { get; set; }
    void Reset();
}

