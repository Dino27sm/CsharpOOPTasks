using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Citizen> objectsData = new HashSet<Citizen>();
            int numPeoples = int.Parse(Console.ReadLine());
            for (int i = 0; i < numPeoples; i++)
            {
                string[] partialData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (partialData.Length == 4)
                {
                    Citizen citizenObject = new Citizen(partialData[0], partialData[1], partialData[2], partialData[3]);
                    objectsData.Add(citizenObject);
                }
                else if (partialData.Length == 3)
                {
                    Citizen rebelObject = new Rebel(partialData[0], partialData[1], partialData[2]);
                    objectsData.Add(rebelObject);
                }
            }
            string aLine = "";
            while ((aLine = Console.ReadLine()) != "End")
            {
                foreach (Citizen citizen in objectsData)
                {
                    if (citizen.Name == aLine)
                    {
                        if (citizen.GetType().Name == nameof(Citizen))
                            citizen.BuyFood();
                        else if (citizen.GetType().Name == nameof(Rebel))
                        {
                            Rebel r = (Rebel)citizen;
                            r.BuyFood();
                        }
                    }
                }
            }
            int sumFood = 0;
            foreach (Citizen citizen in objectsData)
            {
                sumFood += citizen.Food;
            }
            Console.WriteLine(sumFood);
        }
    }
}
