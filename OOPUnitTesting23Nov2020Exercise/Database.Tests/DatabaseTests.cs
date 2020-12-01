using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorAcceptsIntArrayWithUpto16Elements()
        {
            int[] inpArray = Enumerable.Range(1, 16).ToArray();
            Database aDatabase = new Database(inpArray);

            Assert.That(aDatabase.Count, Is.EqualTo(16));
        }

        [Test]
        public void ConstructorDoesNotAcceptsIntArrayWithMoreThan16Elements()
        {
            int[] inpArray = Enumerable.Range(1, 17).ToArray();
            Assert.Throws<InvalidOperationException>(() => new Database(inpArray));
        }

        [Test]
        public void Add17thElementThrowsException()
        {
            int[] inpArray = Enumerable.Range(1, 16).ToArray();
            Database aDatabase = new Database(inpArray);

            Assert.Throws<InvalidOperationException>(() => aDatabase.Add(21));
        }

        [Test]
        public void AddElementNextFreeCell()
        {
            int[] inpArray = Enumerable.Range(1, 10).ToArray();
            Database aDatabase = new Database(inpArray);

            aDatabase.Add(22);
            int[] getFetch = aDatabase.Fetch().ToArray();
            int expectedValue = 22;
            int actualValue = getFetch.Last();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void RemoveLastElementOfArray()
        {
            int[] inpArray = Enumerable.Range(1, 10).ToArray();
            Database aDatabase = new Database(inpArray);

            aDatabase.Remove();
            int[] getFetch = aDatabase.Fetch().ToArray();
            int expectedValue = 9;
            int actualValue = getFetch.Last();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void RemoveElementFromEmtyArrayThrowsException()
        {
            int[] inpArray = new int[0];
            Database aDatabase = new Database(inpArray);

            Assert.Throws<InvalidOperationException>(() => aDatabase.Remove());
        }
    }
}