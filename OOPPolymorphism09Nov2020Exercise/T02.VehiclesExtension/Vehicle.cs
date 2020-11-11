namespace T02.VehiclesExtension
{
    using System;

    internal abstract class Vehicle
    {
        private const double TRUCK_TANK_LEAKAGE = 0.95;

        public Vehicle(double fuel, double consumption, double capacity)
        {
            this.TankCapacity = capacity;
            this.FuelConsumption = consumption;
            if (fuel <= capacity)
                this.FuelAmount = fuel;
            else
                this.FuelAmount = 0;
        }

        protected double FuelAmount { get; set; }
        protected double TankCapacity { get; set; }
        protected double FuelConsumption { get; set; }

        internal virtual void Drive(double distance)
        {
            double fuelSpent = this.FuelConsumption * distance;
            if (fuelSpent <= this.FuelAmount)
            {
                this.FuelAmount -= fuelSpent;
                System.Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
                System.Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
        internal void Refuel(double fuelLoad)
        {
            if (fuelLoad <= 0)
                Console.WriteLine("Fuel must be a positive number");
            else
            {
                if (this.FuelAmount + fuelLoad > this.TankCapacity)
                    Console.WriteLine($"Cannot fit {fuelLoad} fuel in the tank");
                else
                {
                    if (this.GetType().Name == "Truck")
                        fuelLoad *= TRUCK_TANK_LEAKAGE;
                    this.FuelAmount += fuelLoad;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelAmount:F2}";
        }
    }
}
