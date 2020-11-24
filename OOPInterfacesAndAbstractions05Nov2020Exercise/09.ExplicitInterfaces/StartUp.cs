using System;

namespace _09.ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string getLine = Console.ReadLine();
                if (getLine == "End" || string.IsNullOrWhiteSpace(getLine))
                    break;
                string[] inpParts = getLine.Split(" ");
                string name = inpParts[0];
                string country = inpParts[1];
                int age = int.Parse(inpParts[2]);

                Citizen citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                Console.WriteLine(person.GetName());

                IResident resident = citizen;
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
