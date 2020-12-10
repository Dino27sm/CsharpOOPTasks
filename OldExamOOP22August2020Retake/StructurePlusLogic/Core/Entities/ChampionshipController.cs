using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_PARTICIPANTS = 3;
        private readonly CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver aDriver = drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            if (aDriver == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));

            ICar aCar = cars.GetAll().FirstOrDefault(c => c.Model == carModel);
            if (aCar == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));

            aDriver.AddCar(aCar);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace aRace = races.GetAll().FirstOrDefault(r => r.Name == raceName);
            if (aRace == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            IDriver aDriver = drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            if (aDriver == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));

            aRace.AddDriver(aDriver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            string realType = type + "Car";
            if(this.cars.GetAll().Any(c => c.Model == model))
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));

            ICar car = null;
            if(realType == "MuscleCar")
                car = new MuscleCar(model, horsePower);
            else if (realType == "SportsCar")
                car = new SportsCar(model, horsePower);

            this.cars.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.GetAll().Any(d => d.Name == driverName))
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));

            IDriver driver = new Driver(driverName);
            drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (races.GetAll().Any(r => r.Name == name))
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));

            IRace aRace = new Race(name, laps);
            races.Add(aRace);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var aRace = races.GetAll().FirstOrDefault(r => r.Name == raceName);
            if (aRace == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            if (aRace.Drivers.Count < MIN_PARTICIPANTS)
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MIN_PARTICIPANTS));

            int totalLaps = aRace.Laps;
            List<IDriver> raceDrivers = aRace.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(totalLaps))
                .Take(3).ToList();

            this.races.Remove(aRace);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {raceDrivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {raceDrivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {raceDrivers[2].Name} is third in {raceName} race.");

            return sb.ToString().Trim();
        }
    }
}
