namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Part_Constructor_Should_Create_Object()
        {
            Part p1 = new Part("p1", 100);

            Assert.That(p1.Name, Is.EqualTo("p1"));
            Assert.That(p1.Price, Is.EqualTo(100));
        }

        [Test]
        public void Part_Properties_Should_Allow_change()
        {
            Part p1 = new Part("p1", 100);

            p1.Name = "p2";
            p1.Price = 200;

            Assert.That(p1.Name, Is.EqualTo("p2"));
            Assert.That(p1.Price, Is.EqualTo(200));
        }

        [Test]
        public void Computer_Constructor_Should_Create_Object()
        {
            Computer pc1 = new Computer("hp1");

            Assert.That(pc1.Name, Is.EqualTo("hp1"));
            Assert.That(pc1.Parts.Count, Is.EqualTo(0));
            Assert.IsNotNull(pc1.Parts);
        }

        [Test]
        public void Computer_Should_Throw_Ex_If_Name_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(null));
        }

        [Test]
        public void Computer_Should_Throw_Ex_If_Name_WhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer("   "));
        }

        [Test]
        public void IReadOnlyCollection_Should_Take_Parts()
        {
            Part p1 = new Part("p1", 100);
            Part p2 = new Part("p2", 200);
            Computer pc1 = new Computer("hp1");

            pc1.AddPart(p1);
            pc1.AddPart(p2);

            Assert.That(pc1.Parts.Count, Is.EqualTo(2));
        }

        [Test]
        public void IReadOnlyCollection_Should_Calculate_Sum_OK()
        {
            Part p1 = new Part("p1", 100);
            Part p2 = new Part("p2", 200);
            Computer pc1 = new Computer("hp1");

            pc1.AddPart(p1);
            pc1.AddPart(p2);

            Assert.That(pc1.TotalPrice, Is.EqualTo(300));
        }

        [Test]
        public void AddPart_Should_Throw_Ex_If_Add_Null()
        {
            Part p1 = new Part("p1", 100);
            Part p2 = new Part("p2", 200);
            Computer pc1 = new Computer("hp1");

            Assert.Throws<InvalidOperationException>(() => pc1.AddPart(null));
        }

        [Test]
        public void RemovePart_Should_Reove_Part_OK()
        {
            Part p1 = new Part("p1", 100);
            Part p2 = new Part("p2", 200);
            Computer pc1 = new Computer("hp1");

            pc1.AddPart(p1);
            pc1.AddPart(p2);

            Assert.IsTrue(pc1.RemovePart(p1));
            Assert.That(pc1.Parts.Count, Is.EqualTo(1));
        }


        [Test]
        public void GetPart_Should_Get_Part_OK()
        {
            Part p1 = new Part("p1", 100);
            Part p2 = new Part("p2", 200);
            Computer pc1 = new Computer("hp1");

            pc1.AddPart(p1);
            pc1.AddPart(p2);
            Part p3 = pc1.GetPart("p2");

            Assert.That(p3.Name, Is.EqualTo("p2"));
            Assert.That(p3.Price, Is.EqualTo(200));
        }

        [Test]
        public void GetPart_Should_Get_Null_OK()
        {
            Part p1 = new Part("p1", 100);
            Part p2 = new Part("p2", 200);
            Computer pc1 = new Computer("hp1");

            pc1.AddPart(p1);
            pc1.AddPart(p2);
            Part p3 = pc1.GetPart("p7");

            Assert.IsNull(pc1.GetPart("p7"));
            Assert.That(pc1.Parts.Count, Is.EqualTo(2));
        }
    }
}