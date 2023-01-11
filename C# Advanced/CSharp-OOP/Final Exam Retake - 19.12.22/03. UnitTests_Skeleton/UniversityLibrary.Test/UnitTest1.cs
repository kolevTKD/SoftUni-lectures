namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Collections.Generic;

    public class Tests
    {
        private List<TextBook> textBooks;
        private UniversityLibrary universityLibrary;

        [SetUp]
        public void Setup()
        {
            this.textBooks = new List<TextBook>();
            this.universityLibrary = new UniversityLibrary();
        }

        [Test]
        public void TestingCtroSettings()
        {
            CollectionAssert.AreEqual(textBooks, universityLibrary.text)
        }
    }
}