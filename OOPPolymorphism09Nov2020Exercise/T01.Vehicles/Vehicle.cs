namespace T01.Vehicles
{
    using System;

    internal class Vehicle
    {
        internal double Fuel { get; set; }
        internal double FuelConsumptionKm { get; set; }

        internal Vehicle(double fuel, double consumption)
        {
            this.Fuel = fuel;
            this.FuelConsumptionKm = consumption;
        }

        internal void Drive(double distance)
        {
            double consumedFuel = this.FuelConsumptionKm * distance;
            if (consumedFuel <= this.Fuel)
            {
                this.Fuel -= consumedFuel;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        internal virtual void Refuel(double fuelLoad)
        {
            this.Fuel += fuelLoad;
        }
    }
}
