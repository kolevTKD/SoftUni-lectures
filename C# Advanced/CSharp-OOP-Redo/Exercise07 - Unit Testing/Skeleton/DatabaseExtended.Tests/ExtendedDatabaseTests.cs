namespace DatabaseExtended.Tests
{
    using System;
    using System.Linq;

    using ExtendedDatabase;

    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person actualPerson;
        private Person[] actualPeople;
        private Database actualDb;

        [SetUp]
        public void Setup()
        {
            actualDb = new Database();

            actualPeople = new Person[]
            {
                new Person(0, "0"),
                new Person(1, "1"),
                new Person(2, "2"),
                new Person(3, "3"),
                new Person(4, "4"),
                new Person(5, "5"),
                new Person(6, "6"),
                new Person(7, "7"),
                new Person(8, "8"),
                new Person(9, "9"),
                new Person(10, "10"),
                new Person(11, "11"),
                new Person(12, "12"),
                new Person(13, "13"),
                new Person(14, "14"),
                new Person(15, "15"),
            };

        }

        [TestCase(0)]
        [TestCase(long.MinValue)]
        [TestCase(long.MaxValue)]
        public void TestIfPersonCtorSetsIdCorrectly(long value)
        {
            actualPerson = new Person(value, null);

            Assert.AreEqual(value, actualPerson.Id);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("A")]
        [TestCase("George")]
        [TestCase("laskfjascjpoafja;fdmnasfpoasdmafoafapdo!@#$%^&*(()_+-\"\\?><:")]
        public void TestIfPersonCtorSetsUserNameCorrectly(string userName)
        {
            actualPerson = new Person(0, userName);

            Assert.AreEqual(userName, actualPerson.UserName);
        }

        [TestCase(1)]
        [TestCase(7)]
        [TestCase(16)]
        public void TestIfCountPropIsCountingCorrectly(int num)
        {
            actualDb = new Database();
            for (int i = 0; i < num; i++)
            {
                actualDb.Add(actualPeople[i]);
            }

            int expected = num;
            Assert.AreEqual(expected, actualDb.Count);

        }

        [Test]
        public void TestIfThrowsIfTryAddingPersonWithExistingIdInPeople()
        {
            actualDb.Add(actualPeople[0]);

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualDb.Add(new Person(0, "Gosho"));
            }, "There is already user with this Id!");
        }

        [Test]
        public void TestIfThrowsIfTryAddingPersonWithExistingUserNameInPeople()
        {
            actualDb.Add(actualPeople[0]);

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualDb.Add(new Person(400, "0"));
            }, "There is already user with this username!");
        }

        [Test]
        public void TestIfThrowsIfTryAddingWithCountOf16()
        {
            actualDb = new Database(actualPeople);

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualDb.Add(new Person(40, "40"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void TestIfAddRangeMethodThroughCtorThrowsIfCountOfDataGreaterThan16()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                actualDb = new Database(actualPeople.Concat(new Person[] { new Person(28, "28") }).ToArray());
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void TestIfAddRangeMethodThroughCtorAddsPeopleCorrectly()
        {
            actualDb = new Database(actualPeople);
            Assert.AreEqual(16, actualDb.Count);
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(16)]
        public void TestIfRemoveMethodRemoveCorrectly(int num)
        {
            actualDb = new Database(actualPeople);
            int expectedCount = actualDb.Count - num;

            for (int i = 0; i < num; i++)
            {
                actualDb.Remove();
            }

            Assert.AreEqual(expectedCount, actualDb.Count);
        }

        [Test]
        public void TestIfThrowsIfRemoveAndCountIs0()
        {
            actualDb = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualDb.Remove();
            });
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestIfThrowsIfFindByUserNameIfNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                actualDb.FindByUsername(name);
            }, "Username parameter is null!");
        }

        [TestCase("Gosho")]
        [TestCase("Spas")]
        public void TestIfThrowsIfFindByUserNameIfNameNotExisting(string name)
        {
            //actualDb = new Database(actualPeople);

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualDb.FindByUsername(name);
            }, "No user is present by this username!");
        }

        [TestCase("0")]
        [TestCase("8")]
        [TestCase("15")]
        public void TestIfReturnsTheCorrectPersonThroughFindByUserName(string name)
        {
            actualDb = new Database(actualPeople);
            Person expectedPerson = actualPeople.FirstOrDefault(n => n.UserName == name);
            Person actualPerson = actualDb.FindByUsername(name);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [TestCase(1000)]
        [TestCase(long.MaxValue)]
        public void TestIfThrowsIfFindByIdPersonNotExists(long id)
        {
            //actualDb = new Database(actualPeople);

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualDb.FindById(id);
            }, "No user is present by this ID!");
        }

        [TestCase(-1)]
        [TestCase(-100000)]
        [TestCase(long.MinValue)]
        public void TestIfThrowsIfIdIsNegativeNumber(long id)
        {
            actualDb = new Database(actualPeople);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                actualDb.FindById(id);
            }, "Id should be a positive number!");
        }

        [TestCase(0)]
        [TestCase(8)]
        [TestCase(15)]
        public void TestIfFindByIdReturnsTheCorrectPerson(long id)
        {
            actualDb = new Database(actualPeople);

            Person expectedPerson = actualPeople.FirstOrDefault(p => p.Id == id);
            Person actualPerson = actualDb.FindById(id);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void TestIfActualPersonArrayIsTheSameAsTheExpected()
        {
            actualDb = new Database(actualPeople);

            Person[] actualDbPeople = new Person[16];

            for (int i = 0; i < actualDb.Count; i++)
            {
                actualPerson = actualDb.FindById(i);
                actualDbPeople[i] = actualPerson;
            }

            CollectionAssert.AreEqual(actualPeople, actualDbPeople);
        }

        [Test]
        public void TestIfAddMethodAddsCorrectly()
        {
            actualDb = new Database();
            actualDb.Add(new Person(1000, "Spiridon"));

            Assert.AreEqual(1, actualDb.Count);
        }

        [Test]
        public void TestAddMethodCounter()
        {
            actualDb = new Database();
            actualDb.Add(new Person(1000, "Spiridon"));

            Assert.AreEqual(1, actualDb.Count);
        }

        [Test]
        public void TestIfPersonOnCountAfterRemoveIsNull()
        {
            actualDb = new Database(actualPeople);
            actualDb.Remove();

            int count = actualDb.Count;

            Assert.AreEqual(null, actualPeople[count] = null);
        }

    }
}