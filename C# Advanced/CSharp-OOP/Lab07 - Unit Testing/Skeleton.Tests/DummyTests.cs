using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int healthPoints;
        private int experiencePoints;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            this.healthPoints = 30;
            this.experiencePoints = 10;
            this.dummy = new Dummy(healthPoints, experiencePoints);
        }

        [Test]
        public void DummyConstructorSetsDataProperly()
        {
            Assert.AreEqual(healthPoints, dummy.Health);
        }

        [Test]
        public void DummyShouldLooseHealthWhenAttacked()
        {
            for (int i = 0; i < 10; i++)
            {
                dummy.TakeAttack(1);
            }

            Assert.AreEqual(this.healthPoints - 10, this.dummy.Health);
        }

        [Test]
        public void DummyShouldThrowExceptionWhenAttackedWith0Health()
        {
            dummy = new Dummy(0, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void DummyShouldThrowExceptionWhenLessThan0HealthAndAttacked()
        {
            dummy = new Dummy(-10, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void DeadDummyShouldGiveExperience()
        {
            dummy = new Dummy(-1, 10);

            Assert.AreEqual(this.experiencePoints, dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyCannotGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }

        [Test]
        public void DummyIsDeadIndeed()
        {
            dummy = new Dummy(0, 30);
            Assert.IsTrue(dummy.IsDead());
        }
    }
}