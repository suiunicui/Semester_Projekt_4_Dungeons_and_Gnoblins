using GameEngine.Abstract_Class;
using GameEngine.Implementations;
using NUnit.Framework;
using NSubstitute;

namespace GameEngineTest.ActorTest;

[TestFixture]
public class EnemyTest
{
    private Enemy uut;
    private DiceRoller basicDiceRoller;
    private Player player;
    [SetUp]
    public void SetUp()
    {
        basicDiceRoller = Substitute.For<DiceRoller>();
        player = Substitute.For<Player>((uint) 10, (uint) 16, null);
        uut = new Enemy(10, 16, (20,1), 5, basicDiceRoller);
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
    public void Constructor_DamageDice_CorrectInstantiation()
    {
        Assert.That(uut.DamageDice.Item1,Is.EqualTo(20));
        Assert.That(uut.DamageDice.Item2,Is.EqualTo(1));
    }
     
    [Test]
    public void Constructr_ToHit_CorrectInstantiation()
    {
        Assert.That(uut.ToHit,Is.EqualTo(5));
    }

    [Test]
    public void Hit_DiceRollToHit_LargerThan_EnemyAC_ReturnTrue()
    {
        player.AC.Returns((uint) 16);
        basicDiceRoller.RollDice(20).Returns((uint) 18);
        bool expectedHitResult = true;
        bool actualHitResult = uut.Hit(player).hasHit;
        Assert.That(actualHitResult,Is.EqualTo(expectedHitResult));
    }

    [Test]
    public void Hit_DiceRollToHit_EqualTo_EnemyAC_ReturnTrue()
    {
        player.AC.Returns((uint) 16);
        basicDiceRoller.RollDice(20).Returns((uint) 11);
        bool expectedHitResult = true;
        bool actualHitResult = uut.Hit(player).hasHit;
        Assert.That(actualHitResult,Is.EqualTo(expectedHitResult));
    }

    [Test]
    public void Hit_DiceRollToHit_LessThan_EnemyAC_ReturnFalse()
    {
        player.AC.Returns((uint) 16);
        basicDiceRoller.RollDice(20).Returns((uint) 1);
        bool expectedHitResult = false;
        bool actualHitResult = uut.Hit(player).hasHit;
        Assert.That(actualHitResult,Is.EqualTo(expectedHitResult));
 
    }

    [Test]
    public void TakeDamage_IfDamageNotFatal_ThenHPNotZero()
    {
        uut.TakeDamage(8);
        Assert.That(uut.HP, Is.EqualTo(2));
    }

    [Test]
    public void TakeDamage_IfDamageIsFatal_ThenHpIsZero()
    {
        uut.TakeDamage(1000);
        Assert.That(uut.HP, Is.EqualTo(0));
    }

    [Test]
    public void Attack_Damage_PlayerTakesCorrectDamage()
    {
        Player player = new Player(10, 16, null);
        basicDiceRoller.RollDice((uut.DamageDice.numOfSides,uut.DamageDice.numOfDice)).Returns((uint) 3);
        uut.Attack(ref player);
        Assert.That(player.HP, Is.EqualTo(7));
    }
        
}