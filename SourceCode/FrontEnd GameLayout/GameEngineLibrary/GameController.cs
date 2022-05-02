using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngineLibrary.MapCreator;
using GameEngineLibrary.MapImpl;
using GameEngineLibrary.Actors;
using TestHttpClient;
using Backend_API.Models.DTO;

namespace GameEngineLibrary
{

    public class GameController : Descriptor
    {
        public Map GameMap { get; set; }
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        //Making the GameController a Singleton
        private static volatile GameController instance = null;
        private GameController()
        {
          InitializeGame();
        }
        //Singleton logic
        public static GameController Instance 
        { 
            get 
            { 
                if (instance == null)
                {
                    instance = new GameController();
                }
                return instance; 
            } 
        }

        private void InitializeGame()
        {
          GameMap = new Map(new BaseMapCreator());
          CurrentRoom = GameMap.Rooms[0];
          CurrentPlayer = new Player(10,16);
          GameMap.Rooms[0].AddPlayer(CurrentPlayer);
        }

        //Overfører spiller til nyt rum
        public Log MovePlayer(Room curRoom, string direction)
        {
          Log log = new Log();
          
          log.RecordEvent("Previous Room", curRoom.RoomId.ToString());
          
          CurrentRoom.RemovePlayer();
          CurrentRoom = GameMap.GetRoomByDirection(curRoom, direction);
          CurrentRoom.AddPlayer(CurrentPlayer);

          log.RecordEvent("New Room", curRoom.RoomId.ToString());
          log.RecordEvent("New Room Description", CurrentRoom.Description);
         
          return log;
        }
        //Gemmer spil
        public void Savegame()
        {
            HttpController newSave = new HttpController();
            SaveDTO Game = new SaveDTO();
            Game.RoomId = (int) CurrentRoom.RoomId;
            Game.SaveName = "Default";
            newSave.PostSave(Game);
        }

        //Loader gemt spil
        public async void LoadGame(int id)
        {
            HttpController SaveLoader = new HttpController();
            SaveDTO Game = await SaveLoader.GetSave(id);
            CurrentRoom.RemovePlayer();
            CurrentRoom = GameMap.Rooms[Game.RoomId];
            GameMap.Rooms[CurrentRoom.RoomId].AddPlayer(CurrentPlayer);
        }

        //Fjerner spiller fra spillet og viser death screen.
        public void PlayerDead(Player player)
        {
          CurrentRoom.RemovePlayer();
        //Display Death screen
        }
    }
}
