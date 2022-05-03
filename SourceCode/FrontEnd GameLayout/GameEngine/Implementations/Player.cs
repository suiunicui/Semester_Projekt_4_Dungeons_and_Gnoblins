using GameEngine.Actors;

namespace GameEngine.Implementations;

public class Player : Actor
{
    public Player(uint healthPoint, uint armorClass)
    {
        HP = healthPoint;
        AC = armorClass;
    }

}