namespace Database.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database defDb;

        [SetUp]
        public void SetUp()
        {
            this.defDb = new Database();
        }

        [TestCase(new int[] { })] //Edge case with empty []
        [TestCase(new int[] { 1, 2, 3, 4, 5 })] // Main case with valid [] length
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })] //Edge case with max valid [] length
        public void ConstructorIsSettingDataCorrectlyWithValidData(int[] data)
        {
            Database db = new Database(data);
            int expectedLength = data.Length;
            int actualLength = db.Count;

            Assert.AreEqual(expectedLength, actualLength);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 })]
        public void ConstructorIsNotSettingInvalidData(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(null)]
        public void ConstructorIntializationArrayShouldNotBeNull(int[] data)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                Database db = new Database(data);
            }, "Array should not be null!");
        }

        [TestCase(new int[] { })] //Edge case with empty []
        [TestCase(new int[] { 1, 2, 3, 4, 5 })] // Main case with valid [] length
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })] //Edge case with max valid [] length
        public void ConstructorShouldAddDataCorrectlyToTheFields(int[] data)
        {
            Database db = new Database(data);

            int[] expectedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [TestCase(new int[] { })] //Edge case with empty []
        [TestCase(new int[] { 1, 2, 3, 4, 5 })] // Main case with valid [] length
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })] //Edge case with max valid [] length
        public void DataCountShouldBeCorrect(int[] data)
        {
            Database db = new Database(data);

            int expectedCount = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingElementsShouldIncreaseCount()
        {
            int expectedCount = 5;

            for (int i = 1; i <= expectedCount; i++)
            {
                defDb.Add(i);
            }

            Assert.AreEqual(expectedCount, defDb.Count);
        }

        [Test]
        public void AddingElementsShouldAddThemProperly()
        {
            int[] expectedData = new int[5];

            for (int i = 1; i <= 5; i++)
            {
                defDb.Add(i);
                expectedData[i - 1] = i;
            }

            int[] actualData = defDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void AddingMoreThan16ElementsShouldThrowException()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.defDb.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemovingElementFormTheArrayShouldReduceTheCount()
        {
            int initialCount = 5;

            for (int i = 1; i <= initialCount; i++)
            {
                this.defDb.Add(i);
            }

            int removeCount = 2;

            for (int i = 1; i <= removeCount; i++)
            {
                this.defDb.Remove();
            }

            int expectedCount = initialCount - removeCount;
            int actualCount = this.defDb.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemovingElementShouldActuallyRemoveItFromTheCollection()
        {
            int initialCount = 5;

            for (int i = 1; i <= initialCount; i++)
            {
                this.defDb.Add(i);
            }

            int removeCount = 2;

            for (int i = 1; i <= removeCount; i++)
            {
                this.defDb.Remove();
            }

            int[] expectedData = new int[] { 1, 2, 3 };
            int[] actualData = this.defDb.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        public void RemovingElementFromEmptyDatabaseShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defDb.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { })] //Edge case with empty []
        [TestCase(new int[] { 1, 2, 3, 4, 5 })] // Main case with valid [] length
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })] //Edge case with max valid [] length
        public void FetchMethodShouldReturnDatabaseAsArray(int[] data)
        {
            Database db = new Database(data);

            int[] expectedData = data;
            int[] actualData = db.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}
