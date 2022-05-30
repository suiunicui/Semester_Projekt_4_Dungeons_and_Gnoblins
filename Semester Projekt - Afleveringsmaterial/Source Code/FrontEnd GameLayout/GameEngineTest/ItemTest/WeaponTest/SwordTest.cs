using NUnit.Framework;
using GameEngine.Implementations;

namespace GameEngineTest.ItemTest.WeaponTest
{
    [TestFixture]
    public class SwordTest
    {
        private Sword uut;

        [SetUp]
        public void SetUp()
        {
            uut = new Sword((1,8),10, 2);
        }

        [Test]
        public void Constructor_Damage_NotNull()
        {
            Assert.That(uut.Damage, Is.Not.Null);
        }

        [Test]
        public void Constructor_Hit_NotNull()
        {
            Assert.That(uut.Hit, Is.Not.Null);
        }

        [Test]
        public void Constructor_Damage()
        {
            Assert.That(uut.Damage, Is.EqualTo(10));
        }

        [Test]
        public void Constructor_Hit()
        {
            Assert.That(uut.Hit, Is.EqualTo(2));
        }

        [Test]
        public void Constructor_DamageDice_NotNull()
        {
            Assert.That(uut.DamageDice, Is.Not.Null);
        }

        [Test]
        public void Constructor_DamageDice_CorrectDamageDice()
        {
            Assert.That(uut.DamageDice.Item1, Is.EqualTo(1));
            Assert.That(uut.DamageDice.Item2, Is.EqualTo(8));
        }
    }
}
