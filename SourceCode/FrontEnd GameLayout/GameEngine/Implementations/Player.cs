using GameEngine.Abstract_Class;
using GameEngine.Actors;

namespace GameEngine.Implementations;

public class Player : Actor
{
    public Weapon? EquippedWeapon { get; set; } = null;
    public Shield? EquippedShield { get; set; } = null;
    public override uint AC
    {
        get
        {
            if (EquippedShield != null)
            {
                return base.AC + EquippedShield.AC;
            }
            return base.AC;
        }
        set { base.AC = value; }
    }
    public List<Item> Inventory { get; set; } = new List<Item>();
    private DiceRoller _diceRoller;

    public Player(uint healthPoint, uint armorClass)
    {
        HP = healthPoint;
        AC = armorClass;
        _diceRoller = new BasicDiceRoller();
    }
    public Player(uint healthPoint, uint armorClass, Weapon weapon)
    {
        HP = healthPoint;
        AC = armorClass;
        EquippedWeapon = weapon;
        _diceRoller = new BasicDiceRoller();
    }

    public Player(uint healthPoint, uint armorClass, Weapon weapon, DiceRoller diceRoller) : this(healthPoint, armorClass, weapon)
    {
        _diceRoller = diceRoller;
    }

    public virtual (bool hasHit, bool hasCrit) Hit(Enemy enemy)
    {
        if (EquippedWeapon != null)
        {
            uint diceRoll = _diceRoller.RollDice(20);
            uint toHit = EquippedWeapon.Hit;

            if (diceRoll + toHit >= enemy.AC)
            {
                if (diceRoll == 20)
                    return (true, true);
                return (true, false);
            }
        }
        return (false, false);
    }

    public virtual void TakeDamage(uint damage)
    {
        if (damage >= HP)
        {
            HP = 0;
            return;
        }

        HP -= damage;
    }
    
    public virtual uint Attack(ref Enemy enemy)
    {
        if (EquippedWeapon != null)
        {
            uint damageDealt = _diceRoller.RollDice(EquippedWeapon.DamageDice) 
                               + EquippedWeapon.Damage;
            enemy.TakeDamage(damageDealt);
            return damageDealt;
        }
        return 0;
    }

    public virtual uint AttackCrit(ref Enemy enemy)
    {
        if (EquippedWeapon != null)
        {
            uint numOfSides = EquippedWeapon.DamageDice.numOfSides;
            uint numOfDice = EquippedWeapon.DamageDice.numOfDice;

            uint damageDealt = _diceRoller.RollDice((numOfSides, numOfDice))
                               + _diceRoller.RollDice((numOfDice, numOfDice));

            enemy.TakeDamage(damageDealt + EquippedWeapon.Damage);
            return damageDealt;
        }

        return 0;
    }
}