using System.Text.RegularExpressions;

namespace GameEngine
{
    public class Dice
    {
        private Regex _diceRollRegex;

        public Dice()
        {
        _diceRollRegex = new Regex(@"\G[1-9]([0-9]*)[d][1-9]([0-9]*)");
        }
        
        #region Properties

        public Regex DiceRollRegex
        {
          get { return _diceRollRegex; }
        }

        #endregion

        #region Methods

        public int RollDice(string diceString)
        {
            Match match = DiceRollRegex.Match(diceString);
            if (!match.Success)
            {
                throw new ArgumentException("Please use strings with format [1-9]([0-9]*)[d][1-9]([0-9]*)");
            }
            
            string[] diceElements = diceString.Split("d"); 
            Random random = new Random(); 
            int rollResult = (int) random.NextInt64(Int64.Parse(diceElements[0]), Int64.Parse(diceElements[1]+1));

            return rollResult;
        }


        #endregion
    }
}