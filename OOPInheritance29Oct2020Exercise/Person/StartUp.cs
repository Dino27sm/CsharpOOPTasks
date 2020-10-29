using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person personOne;
            if(age <= 15)
            {
                personOne = new Child(name, age);
            }
            else
            {
                personOne = new Person(name, age);
            }
            Console.WriteLine(personOne);
        }
    }
}