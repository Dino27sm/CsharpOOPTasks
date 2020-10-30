namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animalList = new List<Animal>();
            string inpLine = "";
            while((inpLine = Console.ReadLine()) != "Beast!")
            {
                string animalType = inpLine;
                string[] readInfo = Console.ReadLine().Split();

                string name = readInfo[0];
                int age = int.Parse(readInfo[1]);
                string gender = null;
                if (readInfo.Length > 2)
                    gender = readInfo[2];

                bool validNameAgeGender = !string.IsNullOrWhiteSpace(name) 
                    && (gender == "Male" || gender == "Female" || gender == null) && (age > 0);
                bool validAnimalType = animalType == "Dog" || animalType == "Cat" || animalType == "Frog"
                    || animalType == "Kitten" || animalType == "Tomcat";

                if (validNameAgeGender && validAnimalType)
                {
                    Animal animalObject = null;
                    if (animalType == "Dog")
                        animalObject = new Dog(name, age, gender);
                    else if (animalType == "Frog")
                        animalObject = new Frog(name, age, gender);
                    else if (animalType == "Cat")
                        animalObject = new Cat(name, age, gender);
                    else if (animalType == "Kitten")
                        animalObject = new Kitten(name, age);
                    else if (animalType == "Tomcat")
                        animalObject = new Tomcat(name, age);

                    animalList.Add(animalObject);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
            foreach (var animal in animalList)
                PrintAnimal(animal);
        }

        public static void PrintAnimal(Animal inpAnimal)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{inpAnimal.GetType().Name}");
            sb.AppendLine($"{inpAnimal.Name} {inpAnimal.Age} {inpAnimal.Gender}");
            sb.AppendLine($"{inpAnimal.ProduceSound()}");
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}

