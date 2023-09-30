namespace Database.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database actualDb;

        [SetUp]
        public void Setup()
        {
            actualDb = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestIfConstructorSetsDataCorrectly(int[] data)
        {
            actualDb = new Database(data);
            CollectionAssert.AreEqual(data, actualDb.Fetch());
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestIfCountReturnsRightCount(int[] data)
        {
            actualDb = new Database(data);
            Assert.AreEqual(data.Length, actualDb.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 })]
        public void TestIfThrowsExceptionWhenCountOver16(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                actualDb = new Database(data);

            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(1)]
        [TestCase(6)]
        [TestCase(16)]
        public void TestIfAddMethodAddsAccordingly(int num)
        {
            actualDb = new Database();
            for (int i = 1; i <= num; i++)
            {
                actualDb.Add(i);
            }

            Assert.AreEqual(num, actualDb.Count);
        }

        [TestCase(17)]
        [TestCase(21)]
        public void TestIfAddMethodThrowsIfMoreThan16ElementsAreAdded(int num)
        {
            actualDb = new Database();
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 1; i <= num; i++)
                {
                    actualDb.Add(i);
                }
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(8)]
        [TestCase(16)]
        public void TestIfCountActsAccordinglyWhenRemovingElement(int num)
        {
            actualDb = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            int expectedCount = actualDb.Count - num;

            for (int i = 0; i < num; i++)
            {
                actualDb.Remove();
            }

            Assert.AreEqual(expectedCount, actualDb.Count);
        }

        [Test]
        public void TestIfThrowsExceptionWhenRemovingFromEmptyData()
        {
            actualDb = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                actualDb.Remove();
            }, "The collection is empty!");
        }
    }
}
