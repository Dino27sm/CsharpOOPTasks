using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        public string make;
        public string model;
        public double fuelConsumption;
        public double fuelCapacity;

        public Car aCar;

        [SetUp]
        public void Setup()
        {
            this.make = "VW";
            this.model = "Tiguan";
            this.fuelConsumption = 10.0;
            this.fuelCapacity = 60.0;

            this.aCar = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void ConstructorInitialization()
        {
            Assert.AreEqual(0.0, aCar.FuelAmount);
            Assert.AreEqual(make, aCar.Make);
            Assert.AreEqual(model, aCar.Model);
            Assert.AreEqual(fuelConsumption, aCar.FuelConsumption);
            Assert.AreEqual(fuelCapacity, aCar.FuelCapacity);
        }

        [Test]
        public void CarPropertyMakeNullOrEmptySet()
        {
            string emptyMake = "";
            string nullMake = null;

            Assert.Throws<ArgumentException>(() => new Car(emptyMake, model, fuelConsumption, fuelCapacity));
            Assert.Throws<ArgumentException>(() => new Car(nullMake, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CarPropertyModelNullOrEmptySet()
        {
            string emptyModel = "";
            string nullModel = null;

            Assert.Throws<ArgumentException>(() => new Car(make, emptyModel, fuelConsumption, fuelCapacity));
            Assert.Throws<ArgumentException>(() => new Car(make, nullModel, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CarPropertyFuelConsumptionValidation()
        {
            double cunsumeFuel = 0.0;

            Assert.Throws<ArgumentException>(() => new Car(make, model, cunsumeFuel, fuelCapacity));
        }

        [Test]
        public void CarPropertyFuelCapacityValidation()
        {
            double capacityFuel = 0.0;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, capacityFuel));
        }

        [Test]
        public void NegativeRefuelAmountShouldThrowExceptio()
        {
            double refuel = 0.0;

            Assert.Throws<ArgumentException>(() => aCar.Refuel(refuel));
        }

        [Test]
        public void RefuelAmountShouldNotExceedCapacity()
        {
            double refuel = 70.0;

            aCar.Refuel(refuel);

            Assert.AreEqual(aCar.FuelAmount, aCar.FuelCapacity);
        }

        [Test]
        public void DriveDistanceFuelShouldNotExceedAvailableFuel()
        {
            double distance = 100.0;
            double fuelNeeded = (distance / 100) * this.fuelConsumption;

            aCar.Refuel(20.0);
            aCar.Drive(distance);

            Assert.That(aCar.FuelAmount, Is.EqualTo(10.0));
        }

        [Test]
        public void IfDriveDistanceFuelExceedAvailableFuelThrowException()
        {
            double distance = 120.0;
            double fuelNeeded = (distance / 100) * this.fuelConsumption;

            aCar.Refuel(11.0);
            
            Assert.Throws<InvalidOperationException>(() => aCar.Drive(distance));
        }
    }
}