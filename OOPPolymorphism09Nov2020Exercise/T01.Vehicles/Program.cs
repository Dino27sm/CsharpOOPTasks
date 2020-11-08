using System;

namespace T01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuel = double.Parse(carData[1]);
            double carConsumption = double.Parse(carData[2]);
            Vehicle carObject = new Car(carFuel, carConsumption);

            string[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuel = double.Parse(truckData[1]);
            double truckConsumption = double.Parse(truckData[2]);
            Vehicle truckObject = new Truck(truckFuel, truckConsumption);

            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] getAction = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string actionType = getAction[0];
                string vehicleType = getAction[1];
                if(actionType == "Drive")
                {
                    double distance = double.Parse(getAction[2]);
                    if(vehicleType == "Car")
                        carObject.Drive(distance);
                    else if (vehicleType == "Truck")
                        truckObject.Drive(distance);
                }
                else if (actionType == "Refuel")
                {
                    double fuelAdd = double.Parse(getAction[2]);
                    if (vehicleType == "Car")
                        carObject.Refuel(fuelAdd);
                    else if (vehicleType == "Truck")
                        truckObject.Refuel(fuelAdd);
                }
            }
            Console.WriteLine($"Car: {carObject.Fuel:F2}");
            Console.WriteLine($"Truck: {truckObject.Fuel:F2}");
        }
    }
}
