namespace FightingArena.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena actualArena;
        private List<Warrior> actualWarriors;

        [SetUp]
        public void Setup()
        {
            actualArena = new Arena();
            actualWarriors = new List<Warrior>();
        }

        [Test]
        public void TestIfArenaCtorInitializesWarriors()
        {
            Arena ctorArena = new Arena();

            Assert.IsNotNull(ctorArena.Warriors);
        }

        [Test]
        public void TestIfWarriorsListIsSetAsIReadonlyCollection()
        {
            Assert.AreEqual(actualWarriors, actualArena.Warriors);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(50)]
        public void TestIfCountIsCountingProperly(int count)
        {
            for (int i = 0; i < count; i++)
            {
                actualArena.Enroll(new Warrior($"A{i}", 100, 100));
            }

            Assert.AreEqual(count, actualArena.Count);
        }

        [Test]
        public void TestIfThrowsIfWarriorAlreadyEnrolled()
        {
            actualArena.Enroll(new Warrior("name", 100, 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualArena.Enroll(new Warrior("name", 100, 100));

            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void TestIfFightMethodSucseeds()
        {
            Warrior w1 = new Warrior("name", 35, 100);
            Warrior w2 = new Warrior("name2", 45, 100);

            int w1ExpectedHp = w1.HP - w2.Damage;
            int w2ExpectedHp = w2.HP - w1.Damage;

            actualArena.Enroll(w1);
            actualArena.Enroll(w2);

            actualArena.Fight(w1.Name, w2.Name);

            int w1ActualHp = actualArena.Warriors.First(w => w.Name == w1.Name).HP;
            int w2ActualHp = actualArena.Warriors.First(w => w.Name == w2.Name).HP;

            Assert.AreEqual(w1ExpectedHp, w1ActualHp);
            Assert.AreEqual(w2ExpectedHp, w2ActualHp);
        }

        [Test]
        public void TestIfThrowsIfWarrior1IsNull()
        {
            Warrior w1 = new Warrior("Gosho", 100, 100);
            Warrior w2 = new Warrior("Spas", 100, 100);

            actualArena.Enroll(w2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualArena.Fight(w1.Name, w2.Name);
            }, $"There is no fighter with name {w1.Name} enrolled for the fights!");
        }

        [Test]
        public void TestIfThrowsIfWarrior2IsNull()
        {
            Warrior w1 = new Warrior("Gosho", 100, 100);
            Warrior w2 = new Warrior("Spas", 100, 100);

            actualArena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualArena.Fight(w1.Name, w2.Name);
            }, $"There is no fighter with name {w2.Name} enrolled for the fights!");
        }
    }
}
