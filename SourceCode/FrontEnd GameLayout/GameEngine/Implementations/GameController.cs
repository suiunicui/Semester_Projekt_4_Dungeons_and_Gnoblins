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

    public async Task Reset()
    {
        Enemy.ResetID();
        Item.ResetID();
        GameMap = new BaseMap(new BaseMapCreator(@"MapLayOutFile"));
        CurrentLocation = GameMap.Rooms[0];
        CurrentPlayer = new Player(10, 14, null);
        CurrentLocation.AddPlayer(CurrentPlayer);
        CombatController = new CombatController(new BasicDiceRoller());
        await GetRoomDescriptionAsync();
        VisitedRooms = new List<uint>();
        SlainEnemies = new List<uint>();
        Inventory = new List<uint>();
        CurrentLocation.Description = GameMap.Rooms[0].Description;
    }

    public async Task GetRoomDescriptionAsync()
    {
        BackEndController roomDescription = new BackEndController();
<<<<<<< HEAD
        foreach (var item in GameMap.Rooms)
        {
            int IntId = Convert.ToInt32(item.Id + 1);
            RoomDescription tempDesc = await roomDescription.GetRoomDescriptionAsync(IntId);
            item.Description = tempDesc.Description;
=======
        foreach (var Item in GameMap.Rooms)
        {
            int IntId = Convert.ToInt32(Item.Id + 1);
            RoomDescription tempDesc = await roomDescription.GetRoomDescriptionAsync(IntId);
            Item.Description = tempDesc.Description;
>>>>>>> FrontEnd
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
<<<<<<< HEAD
=======
        Game.SlainEnemies = SlainEnemies;
        Game.Inventory = Inventory;
        if (CurrentPlayer.EquippedWeapon != null)
        Game.WeaponId = CurrentPlayer.EquippedWeapon.Id;
        if (CurrentPlayer.EquippedShield != null)
        Game.ShieldId = CurrentPlayer.EquippedShield.Id;
        Game.Health = CurrentPlayer.HP;
>>>>>>> FrontEnd
        await backEndController.PostSaveAsync(Game);
    }

    //Loader gemt spil
    public async Task LoadGame(int id)
    {
<<<<<<< HEAD
        //BackEndController SaveLoader = new BackEndController();
=======
        await Reset();
>>>>>>> FrontEnd
        SaveDTO Game = await backEndController.GetSaveAsync(id);
        CurrentLocation.RemovePlayer();
        CurrentLocation = GameMap.Rooms[Game.RoomId];
        VisitedRooms = Game.VisitedRooms;
<<<<<<< HEAD
        GameMap.Rooms[CurrentLocation.Id].AddPlayer(CurrentPlayer);
=======
        SlainEnemies= Game.SlainEnemies;
        Inventory = Game.Inventory;
        CurrentPlayer.HP = Game.Health;
        GameMap.Rooms[CurrentLocation.Id].AddPlayer(CurrentPlayer);
        List<(uint,Item)> temparray = new List<(uint,Item)>();

        foreach (ILocation room in GameMap.Rooms)
        {
            if (room.Chest != null)
            {
                foreach (Item item in room.Chest)
                {
                    if (Inventory.Contains(item.Id))
                    {
                        if (Game.WeaponId == item.Id)
                        {
                            CurrentPlayer.EquippedWeapon = (Weapon)item;
                        }
                        if (Game.ShieldId == item.Id)
                        {
                            CurrentPlayer.EquippedShield = (Shield)item;
                        }
                        CurrentPlayer.Inventory.Add(item);
                        temparray.Add((room.Id, item));
                    }
                }
            }

            foreach ((uint TempRoom,Item TempItem) tempval in temparray)
            {
                GameMap.Rooms[tempval.TempRoom].Chest.Remove(tempval.TempItem);
            }

            if (room.Enemy != null)
            {
                if (SlainEnemies.Contains(room.Enemy.Id))
                {
                    room.RemoveEnemy();
                }
            }
        }

>>>>>>> FrontEnd
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
