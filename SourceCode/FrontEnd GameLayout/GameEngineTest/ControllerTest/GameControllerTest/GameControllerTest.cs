using GameEngine.Implementations;
using GameEngine.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace GameEngineTest.ControllerTest.GameControllerTest;

[TestFixture]
public class GameControllerTest
{
    private GameController uut;

    [SetUp]
    public void SetUp()
    {
        uut = new GameController(new BaseMapCreator(@"TestMap"));
    }

    [Test]
    public void Constructor_CurrentRoom_HasPlayer()
    {
        Assert.That(uut.CurrentLocation.Player, Is.EqualTo(uut.CurrentPlayer));
    }

    [Test]
    public void Move_ChangeRoom_CorrectlyChangeRoom()
    {
        ILocation expectedLocation = uut.GameMap.Rooms[1];
        uut.Move(Direction.South);
        Assert.That(uut.CurrentLocation, Is.EqualTo(expectedLocation));
    }

    [Test]
    public void Move_OldRoom_PlayerIsNull()
    {
        ILocation oldLocation = uut.GameMap.Rooms[0];
        uut.Move(Direction.South);
        Assert.That(oldLocation.Player,Is.Null);
    }

    [Test]
    public void PickUp_ItemIsGoneFromRoom_AddedToInventory()
    {
        uut.Move(Direction.South);
        uut.PickUpItem(uut.CurrentLocation.Chest.ToArray()[0]);

        Assert.That(uut.CurrentLocation.Chest,Is.Empty);
        Assert.That(uut.Inventory, Is.Not.Empty);
        Assert.That(uut.CurrentPlayer.Inventory, Is.Not.Empty);
    }

    [Test]
    public void EliminateEnemy_EnemyGoneFromRoom_AddedToSlainEnemiesList()
    {
        uut.CurrentLocation = uut.GameMap.Rooms[2];

        Assert.That(uut.CurrentLocation.Enemy, Is.Not.Null);
        Assert.That(uut.SlainEnemies, Is.Empty);

        uut.EliminateEnemy();

        Assert.That(uut.CurrentLocation.Enemy, Is.Null);
        Assert.That(uut.SlainEnemies, Is.Not.Empty);
    }
}