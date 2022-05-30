using GameEngine.Abstract_Class;

namespace GameEngine.Implementations
{
    public abstract class Weapon : Item
    {
        public (uint numOfSides, uint numOfDice) DamageDice { get; set; }
        public uint Damage { get; set; }
        public uint Hit { get; set; }
    }
}
