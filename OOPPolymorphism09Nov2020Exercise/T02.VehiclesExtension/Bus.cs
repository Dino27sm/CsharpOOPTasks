namespace T02.VehiclesExtension
{
    internal class Bus : Vehicle
    {
        private const double CONSUMPTION_MODIFIER = 1.4;

        public Bus(double fuel, double consumption, double capacity)
            : base(fuel, consumption + CONSUMPTION_MODIFIER, capacity)
        {
        }

        public void DriveEmpty(double distance)
        {
            this.FuelConsumption -= CONSUMPTION_MODIFIER;
            base.Drive(distance);
            this.FuelConsumption += CONSUMPTION_MODIFIER;
        }
    }
}
