using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MODEL_SYMBOLS = 4;
        private string model;

        public Car(string model, int horsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
        }
        public string Model 
        {
            get => this.model;
            private set => this.model = !(string.IsNullOrWhiteSpace(value) || value.Length < MODEL_SYMBOLS) ? value
                : throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MODEL_SYMBOLS));
        }
        public abstract int HorsePower { get; protected set; }

        public abstract double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps) => (this.CubicCentimeters / this.HorsePower) * laps;
    }
}
