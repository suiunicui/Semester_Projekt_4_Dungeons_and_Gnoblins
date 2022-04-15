using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngineLibrary.MapCreator;
using GameEngineLibrary.MapImpl;

namespace GameEngineLibrary
{

    public class GameController : Descriptor
    {
        public Map GameMap { get; set; }
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public GameController()
        {
          InitializeGame();
        }
        private void InitializeGame()
        {
          GameMap = new Map(new BaseMapCreator());
          CurrentRoom = GameMap.Rooms[0];
          CurrentPlayer = new Player();
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

        //Fjerner spiller fra spillet og viser death screen.
        public void PlayerDead(Player player)
        {
          CurrentRoom.RemovePlayer();
        //Display Death screen
        }
    }
}
