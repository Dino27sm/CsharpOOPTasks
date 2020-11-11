namespace T02.VehiclesExtension
{
    internal class Car : Vehicle
    {
        private const double CONSUMPTION_MODIFIER = 0.9;

        public Car(double fuel, double consumption, double capacity)
            : base(fuel, consumption + CONSUMPTION_MODIFIER, capacity)
        {
        }
    }
}
