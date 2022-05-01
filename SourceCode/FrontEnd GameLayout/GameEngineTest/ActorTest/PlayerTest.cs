using GameEngine.Implementations;
using NUnit.Framework;

namespace GameEngineTest.ActorTest;

[TestFixture]
public class PlayerTest
{
    private Player uut;

    [SetUp]
    public void SetUp()
    {
        uut = new Player(10,16);
    }

    [Test]
    public void Constructor_HP_CorrectInstantiation()
    {
        Assert.That(uut.HP, Is.EqualTo(10));
    }

    [Test]
    public void Constructor_AC_CorrectInstantiation()
    {
        Assert.That(uut.AC,Is.EqualTo(16));
    }
}