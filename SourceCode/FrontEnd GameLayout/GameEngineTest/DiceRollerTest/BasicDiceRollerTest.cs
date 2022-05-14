using NUnit.Framework;
using GameEngine.Implementations;
using System;

namespace GameEngineTest.DiceRollerTest
{
    [TestFixture]
    public class BasicDiceRollerTest
    {
        private BasicDiceRoller uut;

        [SetUp]
        public void SetUp()
        {
            uut = new BasicDiceRoller();
        }

        [Test]
        public void RollDice_NeverReturnLessThanOne()
        {
            Assert.That(uut.RollDice(20), Is.GreaterThan(0));
        }

        [Test]
        public void RollDice_NeverReturnGreaterThanTwenty()
        {
            Assert.That(uut.RollDice(20), Is.LessThan(21));
        }

        [Test]
        public void RollDice_AssumeDiceIsFair()
        {
            uint sum = 0;
            for (int i = 0; i < 100000; i++)
            {
                sum += uut.RollDice(20);
            }

            double expectedAvg = (double) sum / 100000.0;
            Console.WriteLine(expectedAvg);
            Assert.That(expectedAvg, Is.LessThan(10.7));
            Assert.That(expectedAvg, Is.GreaterThan(10.3));
        }
        
        [TestCase(20,1)]
        [TestCase(20,2)]
        [TestCase(20,3)]
        [TestCase(20,4)]
        public void RollDice_MultipleDice_CannotRollLessThanNumOfDice(int numOfSides, int numOfDice)
        {
            uint expectedDiceResult = uut.RollDice(((uint) numOfSides, (uint)numOfDice));
            uint minimumAllowedResult = (uint) numOfDice;
            Assert.That(expectedDiceResult, Is.GreaterThanOrEqualTo(minimumAllowedResult));
        }

        [TestCase(20,1)]
        [TestCase(20,2)]
        [TestCase(20,3)]
        [TestCase(20,4)]
        public void RollDice_MultipleDice_CannotRollGreaterThanNumOfDice_Times_NumOfSides(int numOfSides, int numOfDice)
        {
            uint expectedDiceResult = uut.RollDice(((uint) numOfSides, (uint)numOfDice));
            uint maxAllowedResult = (uint) (numOfSides * numOfDice);
            Assert.That(expectedDiceResult, Is.LessThanOrEqualTo(maxAllowedResult));
        }
    }
}
