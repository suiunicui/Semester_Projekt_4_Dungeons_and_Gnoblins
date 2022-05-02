using System.ComponentModel;
using Backend_API.Models.DTO;
using GameEngine.Interfaces;

namespace GameEngine.Implementations;

public class GameController : IGameController
{
    public IMap GameMap { get; set; }
    public ILocation CurrentLocation { get; set; }
    public Player CurrentPlayer { get; set; }

    private static volatile IGameController instance;
    public GameController(IMapCreator mapCreator)
    {
        GameMap = new BaseMap(mapCreator);
        CurrentLocation = GameMap.Rooms[0];
        CurrentPlayer = new Player(10, 14);
        CurrentLocation.AddPlayer(CurrentPlayer);
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

    //Loader gemt spil
    public async void LoadGame(int id)
    {
        BackEndController SaveLoader = new BackEndController();
        SaveDTO Game = await SaveLoader.GetSaveAsync(id);
        CurrentLocation.RemovePlayer();
        CurrentLocation = GameMap.Rooms[Game.RoomId];
        GameMap.Rooms[CurrentLocation.Id].AddPlayer(CurrentPlayer);
    }
}