namespace FightingArena.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior actualWarrior;

        [Test]
        public void TestIfCtorSetsNameCorrectly()
        {
            actualWarrior = new Warrior("Warrior", 35, 100);

            Assert.AreEqual("Warrior", actualWarrior.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TestIfThrowsIfNameIsEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                actualWarrior = new Warrior(name, 35, 100);

            }, "Name should not be empty or whitespace!");
        }

        [TestCase(1)]
        [TestCase(5555555)]
        [TestCase(int.MaxValue)]
        public void TestIfCtorSetsDamageValueCorrectly(int damage)
        {
            actualWarrior = new Warrior("Warrior", damage, 100);

            Assert.AreEqual(damage, actualWarrior.Damage);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5555555)]
        [TestCase(int.MinValue)]
        public void TestIfThrowsIfDamageValueIs0OrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                actualWarrior = new Warrior("Warrior", damage, 100);

            }, "Damage value should be positive!");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(7842398)]
        [TestCase(int.MaxValue)]
        public void TestIfCtorSetsHpValueCorrectly(int hp)
        {
            actualWarrior = new Warrior("Warrior", 35, hp);

            Assert.AreEqual(hp, actualWarrior.HP);
        }

        [TestCase(-1)]
        [TestCase(-7539365)]
        [TestCase(int.MinValue)]
        public void TestIfThrowsIfHpValueIsNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                actualWarrior = new Warrior("Warrior", 35, hp);

            }, "HP should not be negative!");
        }

        [TestCase(35)]
        [TestCase(100)]
        public void TestIfAttackSetsWarriorHpCorrectly(int damage)
        {
            Warrior attacker = new Warrior("Attacker", damage, 100);
            Warrior defender = new Warrior("Defender", 50, 100);

            Arena arena = new Arena();
            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHp = attacker.HP - defender.Damage;
            int expectedDefenderHp = defender.HP - attacker.Damage;

            attacker.Attack(defender);

            int actualAttackerHp = arena.Warriors.First(w => w.Name == attacker.Name).HP;
            int actualDefenderHp = arena.Warriors.First(w => w.Name == defender.Name).HP;

            Assert.AreEqual(expectedAttackerHp, actualAttackerHp);
            Assert.AreEqual(expectedDefenderHp, actualDefenderHp);
        }

        [Test]
        public void TestIfDefenderHpIsSetTo0IfAttackerHasGreaterAttack()
        {
            Warrior attacker = new Warrior("Attacker", 101, 100);
            Warrior defender = new Warrior("Defender", 50, 100);

            Arena arena = new Arena();
            arena.Enroll(attacker);
            arena.Enroll(defender);

            attacker.Attack(defender);

            int actualDefenderHp = arena.Warriors.First(w => w.Name == defender.Name).HP;

            Assert.AreEqual(0, actualDefenderHp);
        }

        [TestCase(30)]
        [TestCase(12)]
        public void TestIfThrowsIfAttackerHpIsLowerOrEqualToTheMinimumRequiredHp(int hp)
        {
            Warrior attacker = new Warrior("Attacker", 35, hp);
            Warrior defender = new Warrior("Defender", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);

            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30)]
        [TestCase(8)]
        public void TestIfThrowsIfDefenderHpIsLowerOrEqualToTheMinimumRequiredHp(int hp)
        {
            Warrior attacker = new Warrior("Attacker", 35, 100);
            Warrior defender = new Warrior("Defender", 50, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);

            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void TestIFThrowsIfAttackerHasLessHpThanDefendersAttack()
        {
            Warrior attacker = new Warrior("Attacker", 35, 45);
            Warrior defender = new Warrior("Defender", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);

            }, "You are trying to attack too strong enemy");
        }
    }
}