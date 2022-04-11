using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngineLibrary
{

    public class GameController : Descriptor
    {
        public Map GameMap { get; set; }
        public GameController() { }


        public string Move(string direction)
        {
            return direction;
        }
         public string RoomDescription(Room Roomid, string Description)
        {
            //Få beskrivelse af Rum ud fra rummets id
            string roomdescription = Description;

            return roomdescription;
        }
        public void StartGame(Player player)
        {
        //Add map to game
        Room.AddPlayer(Player player)
        
        }
        //Overfører spiller til nyt rum
        public void MovePlayer(Player player)
        {
        Room.AddPlayer(Player player)
        
        }
        //fjerner spiller fra rummet han kom fra
        public void PlayerMoved(Player player)
        {
        Room.Player RemovePlayer()
        }
        //Fjerner spiller fra spillet og viser death screen.
        public void PlayerDead(Player player)
        {
        Room.Player RemovePlayer()
        //Display Death screen
        }
    }
}
