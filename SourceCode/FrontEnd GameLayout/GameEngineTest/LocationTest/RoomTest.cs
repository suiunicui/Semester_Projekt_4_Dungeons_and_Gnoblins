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
    public void AddPlayer_IfRoomHasNoPlayer_CanAddPlayer()
    {
        Player player = new Player(10, 16);
        uut.AddPlayer(player);
        Assert.That(uut.Player, Is.EqualTo(player));
    }

    [Test]
    public void AddPlayer_IfRoomHasPlayer_ThrowMemberOverwriteException()
    {
        Player player = new Player(10, 16);
        uut.AddPlayer(player);
        Assert.Throws<MemberOverwriteException>(() => { uut.AddPlayer(player); });
    }

    [Test]
    public void RemovePlayer_IfRoomHasPlayer_RemovePlayer()
    {
        Player player = new Player(10, 16);
        uut.AddPlayer(player);
        uut.RemovePlayer();
        Assert.That(uut.Player, Is.Null);
    }
}