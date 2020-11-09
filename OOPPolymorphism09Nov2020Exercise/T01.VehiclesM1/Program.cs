using System;

namespace T01.VehiclesM1
{
    class Program
    {
        static void Main(string[] args)
        {
            string readLine = Console.ReadLine();
            Vehicle carObject = CreateVehicle(readLine);
            readLine = Console.ReadLine();
            Vehicle truckObject = CreateVehicle(readLine);

            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] commandParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandParts[0];
                string vehicleType = commandParts[1];
                double argument = double.Parse(commandParts[2]);
                if(command == "Drive")
                {
                    if(vehicleType == "Car")
                        carObject.Drive(argument);
                    else if (vehicleType == "Truck")
                        truckObject.Drive(argument);
                }
                else if (command == "Refuel")
                {
                    if (vehicleType == "Car")
                        carObject.Refuel(argument);
                    else if (vehicleType == "Truck")
                        truckObject.Refuel(argument);
                }
            }
            Console.WriteLine(carObject);
            Console.WriteLine(truckObject);
        }

        static Vehicle CreateVehicle(string readFromConsole)
        {
            string[] vehicleData = readFromConsole.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = vehicleData[0];
            double fuelAmount = double.Parse(vehicleData[1]);
            double fuelConsum = double.Parse(vehicleData[2]);
            Vehicle vehicle = null;
            if (type == "Car") vehicle = new Car(fuelAmount, fuelConsum);
            if (type == "Truck") vehicle = new Truck(fuelAmount, fuelConsum);
            return vehicle;
        }
    }
}
