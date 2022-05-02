using GameEngine.Implementations;
using Newtonsoft.Json.Bson;
using NUnit.Framework;

namespace GameEngineTest.ActorTest;

[TestFixture]
public class EnemyTest
{
    private Enemy uut;

    [SetUp]
    public void SetUp()
    {
        uut = new Enemy(10, 16, 2);
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

    [Test]
    public void Constructor_Damage_CorrectInstantiation()
    {
        Assert.That(uut.Damage,Is.EqualTo(2));
    }
}