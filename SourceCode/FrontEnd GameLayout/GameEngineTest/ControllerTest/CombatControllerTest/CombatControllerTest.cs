using NUnit.Framework;
using NSubstitute;
using GameEngine.Abstract_Class;
using GameEngine.Implementations;

namespace GameEngineTest.ControllerTest.CombatControllerTest
{
    [TestFixture]
    public class CombatControllerTest
    {
        private CombatController uut;
        private DiceRoller combatDiceRoller;
        private DiceRoller playerDiceRoller;
        private DiceRoller enemyDiceRoller;
        private Enemy enemy;
        private Player player;
        private Weapon weapon;

        [SetUp]
        public void SetUp()
        {
            combatDiceRoller = Substitute.For<DiceRoller>();
            playerDiceRoller = Substitute.For<DiceRoller>();
            enemyDiceRoller = Substitute.For<DiceRoller>();
            weapon = Substitute.For<Sword>(((uint) 8, (uint) 1), (uint) 2, (uint) 2);
            player = Substitute.For<Player>((uint) 10, (uint) 16, weapon, playerDiceRoller);
            enemy = Substitute.For<Enemy>((uint) 10, (uint) 16, ((uint) 8, (uint) 1), (uint) 2, enemyDiceRoller);
            uut = new CombatController(combatDiceRoller);
        }

        [Test]
        public void Constructor_default()
        {
            Assert.That(uut.CombatIsOver, Is.False);
        }

        [Test]
        public void EngageCombat_BothPartiesMiss()
        {
            player.AC = 100;
            enemy.AC = 100;

            uut.EngageCombat(ref player, ref enemy);
            player.Received(1).Hit(enemy);
            enemy.Received(1).Hit(player);
            Assert.That(uut.CombatIsOver, Is.False);
        }

        [Test]
        public void EngageCombat_PlayerHit_NoCrit_EnemyNotDead_EnemyMissed()
        {
            player.Hit(enemy).Returns((true, false));
            enemy.Hit(player).Returns((false, false));

            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.Received(1).Attack(ref enemy);
            player.DidNotReceive().AttackCrit(ref enemy);
            enemy.Received(1).Hit(player);
            enemy.DidNotReceive().Attack(ref player);
            enemy.DidNotReceive().AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.False);
        }

        [Test]
        public void EngageCombat_PlayerHit_Crit_EnemyNotDead_EnemyMissed()
        {
            player.Hit(enemy).Returns((true, true));
            enemy.Hit(player).Returns((false, false));

            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.DidNotReceive().Attack(ref enemy);
            player.Received(1).AttackCrit(ref enemy);
            enemy.Received(1).Hit(player);
            enemy.DidNotReceive().Attack(ref player);
            enemy.DidNotReceive().AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.False);
        }

        [Test]
        public void EngageCombat_PlayerHit_EnemyDead()
        {
            player.Hit(enemy).Returns((true,false));
            enemy.HP = 0;

            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.Received(1).Attack(ref enemy);
            player.DidNotReceive().AttackCrit(ref enemy);
            enemy.DidNotReceive().Hit(player);
            enemy.DidNotReceive().Attack(ref player);
            enemy.DidNotReceive().AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.True);
        }

        [Test]
        public void EngageCombat_PlayerMiss_EnemyHit_NoCrit()
        {
            player.Hit(enemy).Returns((false, default));
            enemy.Hit(player).Returns((true, false));
            
            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.DidNotReceive().Attack(ref enemy);
            player.DidNotReceive().AttackCrit(ref enemy);
            enemy.Received(1).Hit(player);
            enemy.Received(1).Attack(ref player);
            enemy.DidNotReceive().AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.False);
        }

        [Test]
        public void EngageCombat_PlayerMiss_EnemyHit_Crit()
        {
            player.Hit(enemy).Returns((false, default));
            enemy.Hit(player).Returns((true, true));

            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.DidNotReceive().Attack(ref enemy);
            player.DidNotReceive().AttackCrit(ref enemy);
            enemy.Received(1).Hit(player);
            enemy.DidNotReceive().Attack(ref player);
            enemy.Received(1).AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.False);
        }

        [Test]
        public void EngageCombat_BothHit_NoCrit()
        {
            player.Hit(enemy).Returns((true, false));
            enemy.Hit(player).Returns((true, false));

            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.Received(1).Attack(ref enemy);
            player.DidNotReceive().AttackCrit(ref enemy);
            enemy.Received(1).Hit(player);
            enemy.Received(1).Attack(ref player);
            enemy.DidNotReceive().AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.False);
        }
 
        [Test]
        public void EngageCombat_BothHit_PlayerCrit()
        {
            player.Hit(enemy).Returns((true, true));
            enemy.Hit(player).Returns((true, false));

            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.DidNotReceive().Attack(ref enemy);
            player.Received(1).AttackCrit(ref enemy);
            enemy.Received(1).Hit(player);
            enemy.Received(1).Attack(ref player);
            enemy.DidNotReceive().AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.False);
        }

        [Test]
        public void EngageCombat_BothHit_EnemyCrit()
        {
            player.Hit(enemy).Returns((true, false));
            enemy.Hit(player).Returns((true, true));

            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.Received(1).Attack(ref enemy);
            player.DidNotReceive().AttackCrit(ref enemy);
            enemy.Received(1).Hit(player);
            enemy.DidNotReceive().Attack(ref player);
            enemy.Received(1).AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.False);
        }
        
        [Test]
        public void EngageCombat_BothHit_BothCrit()
        {
            player.Hit(enemy).Returns((true, true));
            enemy.Hit(player).Returns((true, true));

            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.DidNotReceive().Attack(ref enemy);
            player.Received(1).AttackCrit(ref enemy);
            enemy.Received(1).Hit(player);
            enemy.DidNotReceive().Attack(ref player);
            enemy.Received(1).AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.False);
        }
 
        [Test]
        public void EngageCombat_BothHit_PlayerDead()
        {
            player.Hit(enemy).Returns((true, true));
            enemy.Hit(player).Returns((true, true));

            player.HP = 0;
            
            uut.EngageCombat(ref player, ref enemy);

            player.Received(1).Hit(enemy);
            player.DidNotReceive().Attack(ref enemy);
            player.Received(1).AttackCrit(ref enemy);
            enemy.Received(1).Hit(player);
            enemy.DidNotReceive().Attack(ref player);
            enemy.Received(1).AttackCrit(ref player);
            Assert.That(uut.CombatIsOver, Is.True);
        }






        [Test]
        public void Flee_ReturnsCombatIsOver()
        {
            uut.Flee();
            Assert.That(uut.CombatIsOver, Is.True);
        }
         
        
    }
}
