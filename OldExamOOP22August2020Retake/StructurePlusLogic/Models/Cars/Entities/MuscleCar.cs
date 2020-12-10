using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double Muscle_Cubic = 5000;
        private const int Muscle_MinPower = 400;
        private const int Muscle_MaxPower = 600;

        private int horsePower;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower)
        {
            this.CubicCentimeters = Muscle_Cubic;
        }

        public override double CubicCentimeters { get; }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set => this.horsePower = (value >= Muscle_MinPower && value <= Muscle_MaxPower) ? value
                : throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
        }
    }
}
