namespace T01.VehiclesM1
{
    internal class Truck : Vehicle
    {
        private const double CONSUMPTION_MODIFIER = 1.6;
        private const double REFUEL_MODIFIER = 0.95;

        public Truck(double fuel, double consumption) 
            : base(fuel, consumption)
        {
        }

        internal override double FuelConsumption 
        { 
            get => base.FuelConsumption; 
            set => base.FuelConsumption = value + CONSUMPTION_MODIFIER; 
        }

        internal override void Refuel(double fuelLoad)
        {
            base.Refuel(fuelLoad * REFUEL_MODIFIER);
        }
    }
}
