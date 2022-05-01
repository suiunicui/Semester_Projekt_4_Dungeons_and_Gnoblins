using GameEngine.Actors;

namespace GameEngine.Implementations;

public class Enemy : Actor
{
    public uint Damage { get; set; }
    public Enemy(uint healthPoint, uint armorClass, uint baseDamage)
    {
        HP = healthPoint;
        AC = armorClass;
        Damage = baseDamage;
    }
}