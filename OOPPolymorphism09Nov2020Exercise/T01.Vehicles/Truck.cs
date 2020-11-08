namespace T01.Vehicles
{
    internal class Truck : Vehicle
    {
        private const double REFUEL_MODIFIER = 0.95;
        private const double CUNSUMPTION_MODIFIER = 1.60;

        internal Truck(double fuel, double consumption)
            : base(fuel, consumption + CUNSUMPTION_MODIFIER)
        {
        }

        internal override void Refuel(double fuelLoad)
        {
            base.Refuel(fuelLoad * REFUEL_MODIFIER);
        }
    }
}
