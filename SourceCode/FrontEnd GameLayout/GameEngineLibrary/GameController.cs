using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngineLibrary.Actors;
using GameEngineLibrary.MapCreator;
using GameEngineLibrary.MapImpl;
using TestHttpClient;
using TestHttpClient.Models;

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
        public void Savegame(Room curRoom)
        {
            HttpController newSave = new HttpController();
            Save Game = new Save();
            Game.RoomId = curRoom.RoomId;
            newSave.PostSave(Game);
        }

        //Loader gemt spil
        public async void LoadGame(int id)
        {
            HttpController SaveLoader = new HttpController();
            Save Game = await SaveLoader.GetSave(id);
            CurrentRoom.RoomId = Game.RoomId;
            CurrentRoom.AddPlayer(CurrentPlayer);
        }

        //Fjerner spiller fra spillet og viser death screen.
        public void PlayerDead(Player player)
        {
          CurrentRoom.RemovePlayer();
        //Display Death screen
        }
    }
}
