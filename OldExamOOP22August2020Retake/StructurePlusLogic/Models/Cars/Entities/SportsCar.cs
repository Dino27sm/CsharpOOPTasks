using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double Sport_Cubic = 3000;
        private const int Sport_MinPower = 250;
        private const int Sport_MaxPower = 450;

        private int horsePower;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower)
        {
            this.CubicCentimeters = Sport_Cubic;
        }

        public override double CubicCentimeters { get; }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set => this.horsePower = (value >= Sport_MinPower && value <= Sport_MaxPower) ? value
                : throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
        }
    }
}
