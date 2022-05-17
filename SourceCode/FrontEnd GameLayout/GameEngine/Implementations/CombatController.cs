using GameEngine.Abstract_Class;
using GameEngine.Actors;
using GameEngine.Interfaces;

namespace GameEngine.Implementations
{
    public class CombatController : ICombatController
    {
        private DiceRoller _diceRoller;
        public bool CombatIsOver { get; set; } = false;

        public CombatController(DiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }


        public ILog EngageCombat(ref Player player, ref Enemy enemy)
        {
            ILog log = new Log();

            log += (Log) PlayerTurn(ref player, ref enemy);
            
            if (isDead(enemy))
            {
                log.RecordEvent("Enemy Status", "You have slain the enemy");
                CombatIsOver = true;
                return log;
            }

            log += (Log) EnemyTurn(ref player, ref enemy); 

            if (isDead(player))
            {
                log.RecordEvent("Player Status", "You have been Slain");
                CombatIsOver = true;
                return log;
            }
          
            return log;
        }

        public void Flee()
        {
            CombatIsOver = true;
        }

        private ILog PlayerTurn(ref Player player, ref Enemy enemy)
        {
            ILog log = new Log();

            (bool hasHit, bool hasCrit) playerAttack = player.Hit(enemy);
            if (playerAttack.hasHit)
            {
                if (playerAttack.hasCrit)
                {
<<<<<<< HEAD
                    uint damagaDealt = player.AttackCrit(ref enemy);
                    log.RecordEvent("player attack", "A Critical Strike against the enemy.");
                    log.RecordEvent("player damage", $"The attack dealt {damagaDealt} damage to the enemy.");
=======
                    uint damageDealt = player.AttackCrit(ref enemy);
                    log.RecordEvent("player attack", "A Critical Strike against the enemy.");
                    log.RecordEvent("player damage", $"The attack dealt {damageDealt} damage to the enemy.");
>>>>>>> FrontEnd
                    return log;
                }
                else
                {
                    uint damageDealt = player.Attack(ref enemy);
                    log.RecordEvent("player attack", "You Hit the enemy.");
                    log.RecordEvent("player damage", $"The attack dealt {damageDealt} damage to the enemy.");
                    return log;
                }
            }

            log.RecordEvent("player attack", $"Your attack missed, dealing {0} damage to the enemy.");
            return log;

        }

        private ILog EnemyTurn(ref Player player, ref Enemy enemy)
        {
            ILog log = new Log();

            (bool hasHit, bool hasCrit) enemyAttack = enemy.Hit(player);
            if (enemyAttack.hasHit)
            {
                if (enemyAttack.hasCrit)
                {
                    uint damageDealt = enemy.AttackCrit(ref player);
                    log.RecordEvent("enemy attack", "The enemy made a critical strike against you.");
                    log.RecordEvent("enemy damage", $"The attack dealt {damageDealt} damage to you.");
                    return log;
                }
                else
                {
                    uint damageDealt = enemy.Attack(ref player);
                    log.RecordEvent("enemy attack", "The enemy Hit You.");
                    log.RecordEvent("enemy damage", $"The attack dealt {damageDealt} damage to you.");
                    return log;
                }
            }

            log.RecordEvent("enemy attack", $"The enemy's attack missed, dealing {0} damage to you.");
            return log;
        }
        private bool isDead(Actor actor) => actor.HP == 0;
    }
}
