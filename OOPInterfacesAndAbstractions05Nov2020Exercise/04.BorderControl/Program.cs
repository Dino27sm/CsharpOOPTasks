using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<IIdentifyable> objectsData = new HashSet<IIdentifyable>();
            string aLine = "";
            while((aLine = Console.ReadLine()) != "End")
            {
                string[] partialData = aLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if(partialData.Length == 2)
                {
                    IIdentifyable robotObject = new Robot(partialData[0], partialData[1]);
                    objectsData.Add(robotObject);
                }
                else if (partialData.Length == 3)
                {
                    IIdentifyable citizenObject = new Citizen(partialData[0], partialData[1], partialData[2]);
                    objectsData.Add(citizenObject);
                }
            }
            string spetialDigits = Console.ReadLine();
            foreach (IIdentifyable item in objectsData)
            {
                if(item.Id.EndsWith(spetialDigits))
                    Console.WriteLine(item.Id);
            }
        }
    }
}
