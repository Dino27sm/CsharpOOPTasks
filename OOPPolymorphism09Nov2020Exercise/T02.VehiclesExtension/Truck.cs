namespace T02.VehiclesExtension
{
    using System;

    internal class Truck : Vehicle
    {
        private const double CONSUMPTION_MODIFIER = 1.6;

        public Truck(double fuel, double consumption, double capacity)
            : base(fuel, consumption + CONSUMPTION_MODIFIER, capacity)
        {
        }
    }
}
