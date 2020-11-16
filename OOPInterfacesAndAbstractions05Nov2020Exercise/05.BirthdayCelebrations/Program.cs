using System;
using System.Collections.Generic;

namespace _05.BirthdayCelebrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<IIdentifyable> objectsData = new HashSet<IIdentifyable>();
            string aLine = "";
            while ((aLine = Console.ReadLine()) != "End")
            {
                string[] partialData = aLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (partialData[0] == "Citizen")
                {
                    IIdentifyable citizenObject = new Citizen(partialData[1], partialData[2], partialData[3], partialData[4]);
                    objectsData.Add(citizenObject);
                }
                else if (partialData[0] == "Pet")
                {
                    IIdentifyable petObject = new Pet(partialData[1], partialData[2]);
                    objectsData.Add(petObject);
                }
                else if (partialData[0] == "Robot")
                {
                    IIdentifyable robotObject = new Robot(partialData[1], partialData[2]);
                    objectsData.Add(robotObject);
                }
            }
            string specificYear = Console.ReadLine();
            foreach (IIdentifyable item in objectsData)
            {
                string getType = item.GetType().Name;
                if (getType == "Citizen")
                {
                    Citizen citizen = (Citizen)item;
                    if (citizen.Birthdate.EndsWith(specificYear))
                        Console.WriteLine(citizen.Birthdate);
                }
                else if (getType == "Pet")
                {
                    Pet pet = (Pet)item;
                    if (pet.Birthdate.EndsWith(specificYear))
                        Console.WriteLine(pet.Birthdate);
                }
            }
        }
    }
}
