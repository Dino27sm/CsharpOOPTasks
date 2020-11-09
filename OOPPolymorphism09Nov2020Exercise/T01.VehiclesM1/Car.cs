namespace T01.VehiclesM1
{
    internal class Car : Vehicle
    {
        private const double CONSUMPTION_MODIFIER = 0.9;

        internal override double FuelConsumption 
        {
            get => base.FuelConsumption; 
            set => base.FuelConsumption = value + CONSUMPTION_MODIFIER; 
        }
        public Car(double fuel, double consumption) 
            : base(fuel, consumption)
        {
        }

        internal override void Refuel(double fuelLoad)
        {
            base.Refuel(fuelLoad);
        }
    }
}
