using System.Text.RegularExpressions;

namespace GameEngine;

public class Dice
{
  public readonly Regex DiceRollRegex;
  public Dice()
  {
    DiceRollRegex = new Regex(@"\G[1-9]([0-9]*)[d][1-9]([0-9]*)");
  }

  #region Methods

  public virtual uint RollDiceAndSumResult(string diceString)
  {
    if (!DiceStringMatchesRegex(diceString))
    {
      throw new ArgumentException("Please use strings with format [1-9]([0-9]*)[d][1-9]([0-9]*)");
    }

    uint numOfDice = GetDiceElements(diceString, 0);
    uint numOfDiceSides = GetDiceElements(diceString, 1);

    return RollNDice(numOfDice, numOfDiceSides);
  }

  public bool DiceStringMatchesRegex(string diceString)
  {
    var m = DiceRollRegex.Match(diceString);
    return m.Success;
  }

  #endregion

  #region Private Methods

  private uint RollNDice(uint numOfDice, uint numOfDiceSides, uint sum = 0)
  {
    if (numOfDice == 0)
    {
      return sum;
    }

    sum += RollDie(numOfDiceSides);
    return RollNDice(--numOfDice, numOfDiceSides, sum);
  }
  private uint RollDie(uint numOfSides)
  {
    Random rand = new Random();
    uint result = (uint) rand.NextInt64(1, ++numOfSides);
    return result;
  }
  private uint GetDiceElements(string diceString, uint index)
  {
    var diceElements = diceString.Split("d");
    return uint.Parse(diceElements[index]);
  }

  #endregion
}