namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [TestCase("name1", 1.1)]
        [TestCase("name2", 2.2)]
        public void Present_Class_Object(string name, double magic)
        {
            Present present = new Present(name, magic);

            Assert.AreEqual(name, present.Name);
            Assert.AreEqual(magic, present.Magic);
        }

        [TestCase]
        public void Bag_Class_Object()
        {
            Bag bag = new Bag();

            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [TestCase]
        public void CreateAdd_Null_Present_To_Bag_Ex()
        {
            Present present = new Present("PresentName", 1.1);
            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
            Assert.AreEqual("Successfully added present PresentName.", bag.Create(present));
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
            Assert.AreEqual(1, bag.GetPresents().Count);
        }

        [TestCase]
        public void Remove_Present_OK_NOK()
        {
            Present present = new Present("PresentName", 1.1);
            Bag bag = new Bag();

            bag.Create(present);

            Assert.IsTrue(bag.Remove(present));
            Assert.IsFalse(bag.Remove(present));
        }

        [TestCase]
        public void Get_Present_With_Less_Magic()
        {
            Present present1 = new Present("PresentName1", 1.1);
            Present present2 = new Present("PresentName2", 2.1);
            Present present3 = new Present("PresentName3", 3.1);
            Bag bag = new Bag();

            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            Assert.AreEqual(present1, bag.GetPresentWithLeastMagic());
        }

        [TestCase]
        public void Get_Present_Name()
        {
            Present present1 = new Present("PresentName1", 1.1);
            Present present2 = new Present("PresentName2", 2.1);
            Bag bag = new Bag();

            bag.Create(present1);
            bag.Create(present2);

            Assert.AreEqual(present1, bag.GetPresent("PresentName1"));
            Assert.AreEqual(present2, bag.GetPresent("PresentName2"));
        }
    }
}
