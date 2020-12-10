using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int RACE_SYMBOLS = 5;
        private const int MIN_LAPS = 1;
        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set => this.name = !(string.IsNullOrEmpty(value) || value.Length < RACE_SYMBOLS) ? value
                : throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, RACE_SYMBOLS));
        }

        public int Laps
        {
            get => this.laps;
            private set => this.laps = (value >= MIN_LAPS) ? value
                : throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_LAPS));
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);

            if(!driver.CanParticipate)
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));

            if(this.drivers.Any(d => d.Name == driver.Name))
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));

            this.drivers.Add(driver);
        }
    }
}
