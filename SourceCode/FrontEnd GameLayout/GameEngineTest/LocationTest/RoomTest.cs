using GameEngine.Exceptions;
using GameEngine.Implementations;
using NUnit.Framework;

namespace GameEngineTest.LocationTest;

[TestFixture]
public class RoomTest
{
    private Room uut;

    [SetUp]
    public void SetUp()
    {
        uut = new Room(1);
    }

    [Test]
    public void Constructor_Id_CorrectInstantiation()
    {
        Assert.That(uut.Id, Is.EqualTo(1));
    }

    [Test]
    public void Constructor_Id_IsNotNull()
    {
        Assert.That(uut.Id,Is.Not.Null);
    }

    [Test]
    public void Constructor_Player_HasNoPlayerByDefault()
    {
        Assert.That(uut.Player, Is.Null);
    }

    [Test]
    public void Constructor_Enemy_HasNoEnemyByDefault()
    {
        Assert.That(uut.Enemy,Is.Null);
    }

    [Test]
<<<<<<< HEAD
    public void Constructor_Description_IsNotNull()
    {
        Assert.That(uut.Description,Is.Not.Null);
=======
    public void Constructor_Description_IsNull()
    {
        Assert.That(uut.Description,Is.Null);
>>>>>>> FrontEnd
    }

    [Test]
    public void Constructor_Description_RoomId()
    {
<<<<<<< HEAD
=======
        uut.Description = "Room Id: 2";
>>>>>>> FrontEnd
        Assert.That(uut.Description,Is.EqualTo("Room Id: 2"));
    }

    [Test]
    public void AddPlayer_IfRoomHasNoPlayer_CanAddPlayer()
    {
        Player player = new Player(10, 16, null);
        uut.AddPlayer(player);
        Assert.That(uut.Player, Is.EqualTo(player));
    }

    [Test]
    public void AddPlayer_IfRoomHasPlayer_ThrowMemberOverwriteException()
    {
        Player player = new Player(10, 16, null);
        uut.AddPlayer(player);
        Assert.Throws<MemberOverwriteException>(() => { uut.AddPlayer(player); });
    }

    [Test]
    public void RemovePlayer_IfRoomHasPlayer_RemovePlayer()
    {
        Player player = new Player(10, 16, null);
        uut.AddPlayer(player);
        uut.RemovePlayer();
        Assert.That(uut.Player, Is.Null);
    }

    [Test]
    public void AddEnemy_IfRoomHasNoEnemy_CanAddEnemy()
    {
<<<<<<< HEAD
        Enemy enemy = new Enemy(10, 16, (1, 2), 2);
=======
        Enemy enemy = new Enemy(10, 16, (1, 2), 2, "Test");
>>>>>>> FrontEnd
        uut.AddEnemy(enemy);
        Assert.That(uut.Enemy,Is.EqualTo(enemy));
    }

    [Test]
    public void RemoveEnemy_IfRoomHasEnemy_canRemoveEnemy()
    {
<<<<<<< HEAD
        Enemy enemy = new Enemy(10, 16, (1, 2), 2);
=======
        Enemy enemy = new Enemy(10, 16, (1, 2), 2, "Test");
>>>>>>> FrontEnd
        uut.AddEnemy(enemy);
        uut.RemoveEnemy();
        Assert.That(uut.Enemy,Is.Null);
    }
}