namespace T01.VehiclesM1
{
    internal abstract class Vehicle
    {
        public Vehicle(double fuel, double consumption)
        {
            this.FuelAmount = fuel;
            this.FuelConsumption = consumption;
        }

        internal double FuelAmount { get; set; }
        internal virtual double FuelConsumption { get; set; }

        internal void Drive(double distance)
        {
            double fuelSpent = this.FuelConsumption * distance;
            if (fuelSpent <= this.FuelAmount)
            {
                this.FuelAmount -= fuelSpent;
                System.Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                System.Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
        internal virtual void Refuel(double fuelLoad)
        {
            this.FuelAmount += fuelLoad;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelAmount:F2}";
        }
    }
}
