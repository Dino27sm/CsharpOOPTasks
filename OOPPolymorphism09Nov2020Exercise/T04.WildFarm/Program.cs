using System;
using T04.WildFarm.Animals;
using T04.WildFarm.Foods;
using T04.WildFarm.Factories;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace T04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Animal> animalInfo = new HashSet<Animal>();
            string firstLine = "";
            while((firstLine = Console.ReadLine()) != "End")
            {
                Animal gotAnimal = new AnimalFactory().CreateAimal(firstLine);
                Console.WriteLine(gotAnimal.AnimalSound());

                string secondLine = Console.ReadLine();
                Food gotFood = new FoodFactory().ProduceFood(secondLine);

                if(!gotAnimal.IsMyFood(gotFood))
                    Console.WriteLine($"{gotAnimal.GetType().Name} does not eat {gotFood.GetType().Name}!");

                animalInfo.Add(gotAnimal);
            }
            foreach (Animal animal in animalInfo)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
