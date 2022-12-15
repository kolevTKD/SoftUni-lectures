using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private int attackPoints;
        private int durabilityPoints;
        private Axe axe;

        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.attackPoints = 10;
            this.durabilityPoints = 15;
            this.axe = new Axe(attackPoints, durabilityPoints);

            this.dummy = new Dummy(100, 100);
        }

        [Test]
        public void AxeConstructorProperlySetsDataProperties()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints);
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }

        [Test]
        public void AxeDurabilityDropsAfterEachAttack()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }

            Assert.AreEqual(this.durabilityPoints - 5, this.axe.DurabilityPoints, "Durability does not gets reduced after attack!");
        }

        [Test]
        public void AxeShouldThrowExceptionWhenDurabiltyIs0()
        {
            axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }

        [Test]
        public void AxeShouldThrowExceptionWhenDurabilityIsLessThan0()
        {
            axe = new Axe(10, -10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}