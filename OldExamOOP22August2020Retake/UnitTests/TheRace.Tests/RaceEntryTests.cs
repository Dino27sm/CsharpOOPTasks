using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitCar_Construct_Creates_Car()
        {
            UnitCar car1 = new UnitCar("x6", 400, 3000);

            Assert.That(car1.Model, Is.EqualTo("x6"));
            Assert.That(car1.HorsePower, Is.EqualTo(400));
            Assert.That(car1.CubicCentimeters, Is.EqualTo(3000));
        }

        [Test]
        public void UnitDriver_Construct_Creates_Driver()
        {
            UnitCar car1 = new UnitCar("x6", 400, 3000);
            UnitDriver d1 = new UnitDriver("name1", car1);

            Assert.That(d1.Name, Is.EqualTo("name1"));
            Assert.That(d1.Car.Model, Is.EqualTo("x6"));
        }

        [Test]
        public void UnitDriver_Throw_Excep_If_Name_Null()
        {
            UnitCar car1 = new UnitCar("x6", 400, 3000);
            UnitDriver d1 = new UnitDriver("name1", car1);

            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, car1));
        }
        [Test]
        public void RaceEntry_Construct_Creates_RaceObject()
        {
            UnitCar car1 = new UnitCar("x6", 400, 3000);
            UnitDriver d1 = new UnitDriver("name1", car1);
            RaceEntry r1 = new RaceEntry();

            Assert.That(r1.Counter, Is.EqualTo(0));
        }

        [Test]
        public void AddDriver_Adds_Driver()
        {
            UnitCar car1 = new UnitCar("x6", 400, 3000);
            UnitDriver d1 = new UnitDriver("name1", car1);
            RaceEntry r1 = new RaceEntry();

            r1.AddDriver(d1);
            Assert.That(r1.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_Throw_Excep_If_Adds_Driver_Null()
        {
            UnitCar car1 = new UnitCar("x6", 400, 3000);
            UnitDriver d1 = new UnitDriver("name1", car1);
            RaceEntry r1 = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => r1.AddDriver(null));
        }

        [Test]
        public void AddDriver_Throw_Excep_If_Adds_Duplicate_Driver()
        {
            UnitCar car1 = new UnitCar("x6", 400, 3000);
            UnitDriver d1 = new UnitDriver("name1", car1);
            RaceEntry r1 = new RaceEntry();

            r1.AddDriver(d1);

            Assert.Throws<InvalidOperationException>(() => r1.AddDriver(d1));
        }

        [Test]
        public void CalculateAverageHorsePower_Throw_Excep_If_Paricipants_LessThan_2()
        {
            UnitCar car1 = new UnitCar("x6", 400, 3000);
            UnitDriver d1 = new UnitDriver("name1", car1);
            RaceEntry r1 = new RaceEntry();

            r1.AddDriver(d1);

            Assert.Throws<InvalidOperationException>(() => r1.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_OK_If_Paricipants_MoreThan_1()
        {
            UnitCar car1 = new UnitCar("x6", 400, 3000);
            UnitCar car2 = new UnitCar("x4", 200, 2000);
            UnitDriver d1 = new UnitDriver("name1", car1);
            UnitDriver d2 = new UnitDriver("name2", car2);
            RaceEntry r1 = new RaceEntry();

            r1.AddDriver(d1);
            r1.AddDriver(d2);
            r1.CalculateAverageHorsePower();

            Assert.That(r1.CalculateAverageHorsePower(), Is.EqualTo(300));
            Assert.That(r1.Counter, Is.EqualTo(2));
        }
    }
}