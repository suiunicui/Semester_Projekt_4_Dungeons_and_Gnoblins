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
}