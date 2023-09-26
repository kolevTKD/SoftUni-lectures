namespace Skeleton.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private int health;
        private int experience;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            health = 100;
            experience = 100;
            dummy = new Dummy(health, experience);
        }

        [Test]
        public void TestIfConstructorSetDataCorrectly()
        {
            Assert.AreEqual(health, dummy.Health);
        }

        [Test]
        public void TestIfHealthDepletesAfterEachTakenAttack()
        {
            dummy.TakeAttack(30);
            Assert.AreEqual(health - 30, dummy.Health);
        }

        [Test]
        public void TestIfThrowsExceptionWhenDummyTakeAttackWithZeroHealth()
        {
            dummy = new Dummy(0, experience);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(5);
            });
        }

        [Test]
        public void TestIfThrowsExceptionIfDummyTakeAttackWithNegativeHealth()
        {
            dummy = new Dummy(-1, experience);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(10);
            });
        }

        [Test]
        public void TestIfDummyGivesExperienceWithZeroHealth()
        {
            dummy = new Dummy(0, experience);
            Assert.AreEqual(experience, dummy.GiveExperience());
        }

        [Test]
        public void TestIfDummyGivesExperienceWithNegativeHealth()
        {
            dummy = new Dummy(-1, experience);
            Assert.AreEqual(experience, dummy.GiveExperience());
        }

        [Test]
        public void TestIfThrowsExceptionIfTryGiveExperienceAndDummyIsAlive()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }

        [Test]
        public void TestIfIsDeadWithZeroHealth()
        {
            dummy = new Dummy(0, experience);
            Assert.IsTrue(dummy.IsDead());
        }

        [Test]
        public void TestIfIsDeadWithNegativeHealth()
        {
            dummy = new Dummy(-1, experience);
            Assert.IsTrue(dummy.IsDead());
        }
    }
}