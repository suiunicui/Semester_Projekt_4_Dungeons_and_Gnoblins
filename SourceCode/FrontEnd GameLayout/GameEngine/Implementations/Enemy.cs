using GameEngine.Abstract_Class;
using GameEngine.Actors;

namespace GameEngine.Implementations;

public class Enemy : Actor
{
    private static uint ID = 0;
    public uint Id;

    public (uint numOfSides, uint numOfDice) DamageDice { get; set; }
<<<<<<< HEAD

    public uint ToHit { get; set; }
    private DiceRoller _diceRoller;
    public Enemy(uint healthPoint, uint armorClass, (uint numOfSides, uint numOfDice) damageDice, uint hit)
=======
    public readonly string Name;

    public uint ToHit { get; set; }
    private DiceRoller _diceRoller;
    public Enemy(uint healthPoint, uint armorClass, (uint numOfSides, uint numOfDice) damageDice, uint hit, string name)
>>>>>>> FrontEnd
    {
        ++ID;
        Id = ID;
        HP = healthPoint;
        AC = armorClass;
        ToHit = hit;
        DamageDice = damageDice;
<<<<<<< HEAD
=======
        Name = name;
>>>>>>> FrontEnd
        _diceRoller = new BasicDiceRoller();
    }

    public Enemy(uint healthPoint, uint armorClass, (uint numOfSides, uint numOfDice) damageDice, uint hit, DiceRoller diceRoller)
    {
        HP = healthPoint;
        AC = armorClass;
        ToHit = hit;
        DamageDice = damageDice;
        _diceRoller = diceRoller;
    }

    public virtual (bool hasHit, bool hasCrit) Hit(Player player)
    {
        uint diceRoll = _diceRoller.RollDice(20);
        
        if (diceRoll + ToHit >= player.AC)
        {
            if (diceRoll == 20)
                return (true, true);
            return (true, false);
        }
        return (false, false);
    }

    public virtual uint Attack(ref Player player)
    {
        uint damageDealt = _diceRoller.RollDice(DamageDice);
        player.TakeDamage(damageDealt);
        return damageDealt;
    }

    public virtual uint AttackCrit(ref Player player)
    {
        uint numOfSides = DamageDice.numOfSides;
        uint numOfDice = DamageDice.numOfDice * 2;

        uint damageDealt = _diceRoller.RollDice((numOfSides, numOfDice));
        
        player.TakeDamage(damageDealt);
        return damageDealt;
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

    public static void ResetID()
    {
        ID = 0;
    }
}