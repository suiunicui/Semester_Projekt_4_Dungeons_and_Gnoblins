using GameEngineLibrary;
using NUnit.Framework;

namespace GameEngineLibraryTest
{
    public class RoomTest
    {
        private Room _uut = new();
        [SetUp]
        public void Setup()
        {
            _uut = new Room();
        }

        [Test]
        public void RoomHasNoPlayer()
        {
            Assert.That(_uut.Player, Is.Null);
        }
        
        [Test]
        public void RoomHasNoEnemy()
        {
            Assert.That(_uut.Enemy, Is.Null);
        }

        [Test]
        public void RoomDescriptionIsEmptyByDefault()
        {
          Assert.That(_uut.Description,Is.Empty);
        }

        [Test]
        public void RoomHasDescription()
        {
            _uut.Description = "This is a Room";
            Assert.That(_uut.Description, Is.EqualTo("This is a Room"));
        }

        [Test]
        public void RoomHasId()
        {
            _uut = new Room(1);
            Assert.That(_uut.RoomId, Is.EqualTo(1));
        }

        [Test]
        public void RoomCanAddPlayer()
        {
            Player player = new Player();
            _uut.AddPlayer(player);
            Assert.That(_uut.Player,Is.EqualTo(player));
        }

        [Test]
        public void Room_AddPlayer_ThrowsExceptionIfPlayerIsNotNull()
        {
            Player player = new Player();
            Player player2 = new Player();

            _uut.AddPlayer(player);

            Assert.Throws<MemberOverwriteException>(() => { _uut.AddPlayer(player2); });
        }

        [Test]
        public void RoomCanRemovePlayer()
        {
            Player player = new Player();
            Player removedPlayer;
            _uut.AddPlayer(player);
            removedPlayer = _uut.RemovePlayer();
            Assert.That(_uut.Player, Is.Null);
            Assert.That(removedPlayer, Is.EqualTo(player));
        }

        [Test]
        public void Room_RemovePlayer_ThrowsExceptionIfPlayerIsNull()
        {
            Assert.Throws<MemberOverwriteException>(() => { _uut.RemovePlayer(); });
        }

        [Test]
        public void RoomCanAddEnemy()
        {
            Enemy enemy = new Enemy();
            _uut.AddEnemy(enemy);
        }

        [Test]
        public void Room_AddEnemy_ThrowsExceptionIfEnemyIsNotNull()
        {
            Enemy enemy = new Enemy();
            Enemy enemy2 = new Enemy();

            _uut.AddEnemy(enemy);

            Assert.Throws<MemberOverwriteException>(() => { _uut.AddEnemy(enemy2); });
        }

        [Test]
        public void RoomCanRemoveEnemy()
        {
            Enemy enemy = new Enemy();
            Enemy removedEnemy;
            
            _uut.AddEnemy(enemy);
            removedEnemy = _uut.RemoveEnemy();

            Assert.That(_uut.Enemy, Is.Null);
            Assert.That(removedEnemy, Is.EqualTo(enemy));
        }

        [Test]
        public void Room_RemoveEnemy_ThrowsExceptionIfEnemyIsNull()
        {
          Assert.Throws<MemberOverwriteException>(() => { _uut.RemoveEnemy(); });
        }
    }
}