using GameEngineLibrary.Actors;

namespace GameEngineLibrary
{
    public class Room : Descriptor
    {

        public Room(uint id) 
        {
            RoomId = id;
            Description = Description + (id + 1);
        }

        public Room() { }

        #region Properties

        public uint RoomId { get; }
        public string Description { get; }
        public Player? Player { get; private set; } = null;
        public Enemy? Enemy { get; private set; } = null;
        
        #endregion

        #region Methods
        public void AddPlayer(Player player)
        {
            if (Player != null)
            {
                throw new MemberOverwriteException(
                    "A Player is already in the room and can't be overwritten, pls remove the player first."
                    );
            }

            Player = player;
        }

        public Player RemovePlayer()
        {
            if (Player == null)
            {
                throw new MemberOverwriteException(
                    "There is no player in this room and can't be overwrite, pls add the player first."
                    );
            }
                
            Player playerToReturn = Player;
            Player = null;
            return playerToReturn;
        }

        public void AddEnemy(Enemy enemy)
        {
            if (Enemy != null)
            {
                throw new MemberOverwriteException(
                    "An Enemy is already present in the room and can't be overwritten, pls remove enemy first."
                    );
            }
            
            Enemy = enemy;
        }

        public Enemy RemoveEnemy()
        {
            if (Enemy == null)
            {
                throw new MemberOverwriteException(
                    "There is no enemy in this room and can't be overwritten, pls add an enemy first."
                    );
            }
            Enemy enemytoReturn = Enemy;
            Enemy = null;
            return enemytoReturn;
            
        }
        
        
        #endregion

    }

    public class MemberOverwriteException : Exception
    {
        public MemberOverwriteException(string Message) 
            : base(Message) {}
    }
}
