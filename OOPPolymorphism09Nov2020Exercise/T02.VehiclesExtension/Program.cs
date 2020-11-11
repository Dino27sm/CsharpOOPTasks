using System;

namespace T02.VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] getData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle carObject = new Car(double.Parse(getData[1]), double.Parse(getData[2]), double.Parse(getData[3]));
            getData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle truckObject = new Truck(double.Parse(getData[1]), double.Parse(getData[2]), double.Parse(getData[3]));
            getData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle busObject = new Bus(double.Parse(getData[1]), double.Parse(getData[2]), double.Parse(getData[3]));

            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] commandParts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandParts[0];
                string vehicleType = commandParts[1];
                double argument = double.Parse(commandParts[2]);
                if (command == "Drive")
                {
                    if (vehicleType == "Car")
                        carObject.Drive(argument);
                    else if (vehicleType == "Truck")
                        truckObject.Drive(argument);
                    else if (vehicleType == "Bus")
                        busObject.Drive(argument);
                }
                else if (command == "DriveEmpty")
                {
                    Bus busTemp = (Bus)busObject;
                    busTemp.DriveEmpty(argument);
                }
                else if (command == "Refuel")
                {
                    if (vehicleType == "Car")
                        carObject.Refuel(argument);
                    else if (vehicleType == "Truck")
                        truckObject.Refuel(argument);
                    else if (vehicleType == "Bus")
                        busObject.Refuel(argument);
                }
            }
            Console.WriteLine(carObject);
            Console.WriteLine(truckObject);
            Console.WriteLine(busObject);
        }
    }
}
