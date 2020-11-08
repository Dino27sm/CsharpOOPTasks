namespace T01.Vehicles
{
    internal class Car : Vehicle
    {
        private const double CUNSUMPTION_MODIFIER = 0.9;

        internal Car(double fuel, double consumption)
            : base(fuel, consumption + CUNSUMPTION_MODIFIER)
        {
        }

        internal override void Refuel(double fuelLoad)
        {
            base.Refuel(fuelLoad);
        }
    }
}
