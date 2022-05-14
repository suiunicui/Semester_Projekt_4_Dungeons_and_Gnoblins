using System.ComponentModel;
using GameEngine.Models.DTO;
using GameEngine.Interfaces;
using Backend_API.Models;
using GameEngine.Abstract_Class;

namespace GameEngine.Implementations;

public class GameController : IGameController
{
    public IMap GameMap { get; set; }
    public ILocation CurrentLocation { get; set; }
    public Player CurrentPlayer { get; set; }
    public ICombatController CombatController { get; set; }

    public List<uint> VisitedRooms { get; set; } = new List<uint>();
    public List<uint> SlainEnemies { get; set; } = new List<uint>();
    public List<uint> Inventory { get; set; } = new List<uint>();
    BackEndController backEndController = BackEndController.Instance;

    private static volatile IGameController instance;
    public GameController(IMapCreator mapCreator)
    {
        GameMap = new BaseMap(mapCreator);
        CurrentLocation = GameMap.Rooms[0];
        CurrentPlayer = new Player(10, 14, null);
        CurrentLocation.AddPlayer(CurrentPlayer);
        CombatController = new CombatController(new BasicDiceRoller());
    }
    public static IGameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameController(new BaseMapCreator(@"MapLayOutFile"));
            }
            return instance;
        }
    }

    public async void Reset()
    {
        instance = new GameController(new BaseMapCreator(@"MayLayoutFile"));
        Enemy.resetID();
        await GetRoomDescriptionAsync();
    }

    public async Task GetRoomDescriptionAsync()
    {
        BackEndController roomDescription = new BackEndController();
        foreach (var item in GameMap.Rooms)
        {
            int IntId = Convert.ToInt32(item.Id + 1);
            RoomDescription tempDesc = await roomDescription.GetRoomDescriptionAsync(IntId);
            item.Description = tempDesc.Description;
        }
    }

    //Gemmer spil
    public async Task SaveGame(int id, string Savename)
    {
        //BackEndController newSave = new BackEndController();
        SaveDTO Game = new SaveDTO();
        Game.ID = id;
        Game.RoomId = (int) CurrentLocation.Id;
        Game.SaveName = Savename;
        Game.Username = "null";
        Game.VisitedRooms = VisitedRooms;
        await backEndController.PostSaveAsync(Game);
    }

    //Loader gemt spil
    public async Task LoadGame(int id)
    {
        //BackEndController SaveLoader = new BackEndController();
        SaveDTO Game = await backEndController.GetSaveAsync(id);
        CurrentLocation.RemovePlayer();
        CurrentLocation = GameMap.Rooms[Game.RoomId];
        VisitedRooms = Game.VisitedRooms;
        GameMap.Rooms[CurrentLocation.Id].AddPlayer(CurrentPlayer);
    }

    public ILog Move(Direction dir)
    {
        Log log = new Log();

        log.RecordEvent("Previous Room", CurrentLocation.Id.ToString());

        CurrentLocation.RemovePlayer();
        CurrentLocation = GameMap.GetLocationByDirection(CurrentLocation, dir);
        CurrentLocation.AddPlayer(CurrentPlayer);

        log.RecordEvent("New Room", CurrentLocation.Id.ToString());
        log.RecordEvent("New Room Description", CurrentLocation.Description);

        return log;
    }

    public void EliminateEnemy()
    {
        SlainEnemies.Add(CurrentLocation.Enemy.Id);
        CurrentLocation.RemoveEnemy();
    }

    public void PickUpItem(Item item)
    {
        Inventory.Add(item.Id);
        CurrentPlayer.Inventory.Add(item);
        CurrentLocation.Chest.Remove(item);
    }

}   
