using GameEngine.Abstract_Class;
namespace GameEngine.Implementations
{
    public class BasicDiceRoller : DiceRoller
    {
        public override uint RollDice(uint numOfSides)
        {
            Random random = new Random();
            uint result = (uint) random.Next(1, ((int) numOfSides + 1));

            return result;
        }

        public override uint RollDice((uint numOfSides, uint numOfDice) damageDice, uint sum = 0)
        {
            if (damageDice.numOfDice == 0)
                return sum;

            sum += RollDice(damageDice.numOfSides);

            return RollDice((damageDice.numOfSides, --damageDice.numOfDice), sum);
        }
    }
}
