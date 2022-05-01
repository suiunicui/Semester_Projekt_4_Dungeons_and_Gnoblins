﻿using GameEngine.Implementations;
using GameEngine.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace GameEngineTest.GameControllerTest;

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
        string expectedLocationId = uut.GameMap.Rooms[1].Description;
        uut.Move(Direction.South);
        Assert.That(uut.CurrentLocation.Description, Is.EqualTo(expectedLocationId));
    }

    [Test]
    public void Move_OldRoom_PlayerIsNull()
    {
        ILocation oldLocation = uut.GameMap.Rooms[0];
        uut.Move(Direction.South);
        Assert.That(oldLocation.Player,Is.Null);
    }

}