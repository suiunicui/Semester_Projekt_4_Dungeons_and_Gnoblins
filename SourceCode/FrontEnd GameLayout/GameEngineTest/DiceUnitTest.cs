using System.Text.RegularExpressions;
using GameEngine;
using NUnit.Framework;

namespace GameEngineTest
{
    [TestFixture]
    public class DiceUnitTest
    {
        private Dice uut;
        [SetUp]
        public void Setup()
        {
            uut = new Dice();
        }

        [TestCase("", false)]
        [TestCase("0d0", false)]
        [TestCase("1d0", false)]
        [TestCase("01d1", false)]
        [TestCase("1d01", false)]
        [TestCase("1d1", true)]
        [TestCase("10d1", true)]
        [TestCase("1d10", true)]
        [TestCase("10d10",true)]
        public void DiceClassRegexMustStartWithANoneZeroNumber(string diceRollTestString, bool result)
        {
            Match match = uut.DiceRollRegex.Match(diceRollTestString);
            Assert.That(match.Success, Is.EqualTo(result));
        }

        [TestCase("10d123", true)]
        [TestCase("10dd123", false)]
        [TestCase("10ddd123", false)]
        [TestCase("10D123", false)]
        public void DiceClassRegexMustContainExactlyOneLowerCapitalD(string diceRollTestString, bool result)
        {
            Match match = uut.DiceRollRegex.Match(diceRollTestString);
            Assert.That(match.Success,Is.EqualTo(result));
        }

    }
}