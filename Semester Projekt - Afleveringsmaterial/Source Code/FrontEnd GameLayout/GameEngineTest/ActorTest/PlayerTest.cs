#nullable disable
using GameEngine.Implementations;
using NUnit.Framework;
using NSubstitute;
using GameEngine.Abstract_Class;

namespace GameEngineTest.ActorTest;

[TestFixture]
public class PlayerTest
{
    private Player uut;
    private Enemy enemy;
    private DiceRoller basicDiceRoller;
    private Weapon weapon;

    [SetUp]
    public void SetUp()
    {
        basicDiceRoller = Substitute.For<DiceRoller>();
        weapon = Substitute.For<Sword>(((uint) 8, (uint) 1), (uint) 2, (uint) 2);
        uut = new Player(10, 16, weapon, basicDiceRoller);
        enemy = new Enemy(10, 10, (10, 1), 2, "test");
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
    public void Constructor_EquippedWeapon_IsNullNotDefault()
    {
        Assert.That(uut.EquippedWeapon, Is.Not.Null);
    }
       
    [Test]
    public void TakeDamage_IfDamageNotFatal_ThenCorrectlyUpdateHP()
    {
        uut.TakeDamage(8);
        Assert.That(uut.HP, Is.EqualTo(2));
    }

    [Test]
    public void TakeDamage_IfDamageIsFatal_ThenHPIsZero()
    {
        uut.TakeDamage(1000);
        Assert.That(uut.HP, Is.EqualTo(0));
    }

    [Test]
    public void Hit_IfPlayerEquippedWeaponNull_DefaultHitIsFalse()
    {
        basicDiceRoller.RollDice(20).Returns((uint)10000);
        uut.EquippedWeapon = null;
        bool expectedHitResult = false;
        (bool Hit, bool) actualHitResult = uut.Hit(enemy);
        Assert.That(actualHitResult.Hit, Is.EqualTo(expectedHitResult));
    }

    [Test]
    public void Hit_DiceRollToHit_LargerThan_EnemyAC_ReturnTrue()
    {
        basicDiceRoller.RollDice(20).Returns((uint) 18);
        bool expectedHitResult = true;
        (bool Hit, bool) actualHitResult = uut.Hit(enemy);
        Assert.That(actualHitResult.Hit, Is.EqualTo(expectedHitResult));
    }

    [Test]
    public void Hit_DiceRollToHit_EqualTo_EnemyAC_ReturnTrue()
    {
        basicDiceRoller.RollDice(20).Returns((uint) 8);
        bool expectedHitResult = true;
        (bool Hit, bool) actualHitResult = uut.Hit(enemy);
        Assert.That(actualHitResult.Hit, Is.EqualTo(expectedHitResult));
    }

    [Test]
    public void Hit_DiceRollToHit_LessThan_EnemyAC_ReturnFalse()
    {
        basicDiceRoller.RollDice(20).Returns((uint) 1);
        bool expectedHitResult = false;
        (bool Hit, bool) actualHitResult = uut.Hit(enemy);
        Assert.That(actualHitResult.Hit,Is.EqualTo(expectedHitResult));
 
    }

    [Test]
    public void Attack_EnemyTakesCorrectDamage()
    {
        basicDiceRoller.RollDice(uut.EquippedWeapon.DamageDice).Returns((uint) 1);
        uut.Attack(ref enemy);
        
        Assert.That(uut.EquippedWeapon, Is.Not.Null);
        Assert.That(enemy.HP, Is.EqualTo(7));
    }

    [Test]
    public void AttackCrit_EnemyTakeCorrectDamage()
    {
        basicDiceRoller.RollDice(uut.EquippedWeapon.DamageDice).Returns((uint) 2, (uint) 2);
        uut.EquippedWeapon.Damage = 2;
        uint damage = uut.AttackCrit(ref enemy);

        Assert.That(uut.EquippedWeapon, Is.Not.Null);
        Assert.That(enemy.HP, Is.EqualTo(4));
    }
}