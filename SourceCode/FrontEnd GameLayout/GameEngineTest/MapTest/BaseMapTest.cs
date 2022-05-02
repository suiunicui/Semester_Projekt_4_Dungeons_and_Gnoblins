using GameEngine.Implementations;
using GameEngine.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace GameEngineTest.MapTest;

[TestFixture]
public class BaseMapTest
{
    private BaseMap uut;

    [SetUp]
    public void SetUp()
    {
        uut = new BaseMap(new BaseMapCreator(@"TestMapLayout"));
    }

    [Test]
    public void Constructor_MapSize_CorrectInstantiation()
    {
        Assert.That(uut.Rooms.Length, Is.EqualTo(20));
    }

    [Test]
    public void GetLocationByDirection_IfValidDirection_NotNull()
    {
        ILocation currentLocation = uut.Rooms[0];
        ILocation newLocation = uut.GetLocationByDirection(currentLocation, Direction.South);
        Assert.That(newLocation, Is.Not.Null);
    }

    [Test]
    public void GetLocationByDirection_IfValidDirection_CorrectLocation()
    {
        ILocation currentLocation = uut.Rooms[0];
        ILocation expectedLocation = uut.Rooms[1];
        
        ILocation newLocation = uut.GetLocationByDirection(currentLocation, Direction.South);
        Assert.That(newLocation, Is.EqualTo(expectedLocation));
    }

    [Test]
    public void GetLocationByDirection_IfInvalidDirection_DoNothing()
    {
        ILocation currentLocation = uut.Rooms[0];
        ILocation expectedLocation = uut.Rooms[0];
        ILocation newLocation = uut.GetLocationByDirection(currentLocation, Direction.East);
        
        Assert.That(newLocation, Is.EqualTo(expectedLocation));
    }


}