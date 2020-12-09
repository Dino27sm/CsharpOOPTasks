namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Part_Create_Object()
        {
            Part part = new Part("p1", 100);

            Assert.That(part.Name, Is.EqualTo("p1"));
            Assert.That(part.Price, Is.EqualTo(100));
        }

        [Test]
        public void Part_Property_Evaluate()
        {
            Part part = new Part("p1", 100);

            part.Name = "pp2";
            part.Price = 200;

            Assert.That(part.Name, Is.EqualTo("pp2"));
            Assert.That(part.Price, Is.EqualTo(200));
        }

        [Test]
        public void Computer_Construct_Instance_Evaluate()
        {
            Computer pc = new Computer("pc1");

            Assert.That(pc.Name, Is.EqualTo("pc1"));
            Assert.That(pc.Parts.Count, Is.EqualTo(0));
        }

        [Test]
        public void Computer_Construct_Throw_Exception_If_Name_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(null));
        }

        [Test]
        public void Computer_Construct_Throw_Exception_If_Name_WhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer("   "));
        }

        [Test]
        public void Computer_AddParts_Throw_Exception_If_Add_Null()
        {
            Computer pc = new Computer("pc1");

            Assert.Throws<InvalidOperationException>(() => pc.AddPart(null));
        }

        [Test]
        public void Computer_AddParts_Evaluate()
        {
            Computer pc = new Computer("pc1");
            Part part1 = new Part("p1", 100);
            Part part2 = new Part("p2", 200);

            pc.AddPart(part1);
            pc.AddPart(part2);

            Assert.That(pc.Parts.Count, Is.EqualTo(2));
            Assert.That(pc.TotalPrice, Is.EqualTo(300));
        }

        [Test]
        public void Computer_RemovePart_Evaluate()
        {
            Computer pc = new Computer("pc1");
            Part part1 = new Part("p1", 100);
            Part part2 = new Part("p2", 200);

            pc.AddPart(part1);
            pc.AddPart(part2);
            pc.RemovePart(part1);

            Assert.That(pc.Parts.Count, Is.EqualTo(1));
        }

        [Test]
        public void Computer_RemovePart_Bool_Evaluate_True()
        {
            Computer pc = new Computer("pc1");
            Part part1 = new Part("p1", 100);
            pc.AddPart(part1);

            Assert.IsTrue(pc.RemovePart(part1));
        }

        [Test]
        public void Computer_RemovePart_Bool_Evaluate_False()
        {
            Computer pc = new Computer("pc1");
            Part part1 = new Part("p1", 100);
            Part part2 = new Part("p2", 200);
            pc.AddPart(part1);

            Assert.IsFalse(pc.RemovePart(part2));
        }

        [Test]
        public void Computer_GetPart_Should_Get_Part()
        {
            Computer pc = new Computer("pc1");
            Part part1 = new Part("p1", 100);
            Part part2 = new Part("p2", 200);
            pc.AddPart(part1);
            pc.AddPart(part2);

            Part getP2 = pc.GetPart("p2");
            Assert.That(getP2.Name, Is.EqualTo(part2.Name));
        }

        [Test]
        public void Computer_GetPart_Should_Get_Null()
        {
            Computer pc = new Computer("pc1");
            Part part1 = new Part("p1", 100);
            pc.AddPart(part1);

            Part getP2 = pc.GetPart("p2");
            Assert.IsTrue(getP2 == null);
        }
    }
}