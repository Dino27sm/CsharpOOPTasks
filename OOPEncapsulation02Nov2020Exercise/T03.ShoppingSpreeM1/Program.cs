using System;
using System.Collections.Generic;

namespace T03.ShoppingSpreeM1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> personsList = new List<Person>();
            List<Product> productList = new List<Product>();
            string[] personsInfo = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfo = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < personsInfo.Length; i++)
            {
                string[] infoParts = personsInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string personName = infoParts[0];
                decimal money = decimal.Parse(infoParts[1]);
                Person newPerson = null;
                try
                {
                    newPerson = new Person(personName, money);
                }
                catch (ArgumentException argException)
                {
                    Console.WriteLine(argException.Message);
                    return;
                }
                personsList.Add(newPerson);
            }

            for (int i = 0; i < productsInfo.Length; i++)
            {
                string[] infoParts = productsInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string productName = infoParts[0];
                decimal price = decimal.Parse(infoParts[1]);
                Product newProduct = null;
                try
                {
                    newProduct = new Product(productName, price);
                }
                catch (ArgumentException argException)
                {
                    Console.WriteLine(argException.Message);
                    return;
                }
                productList.Add(newProduct);
            }

            string readCommand = "";
            while((readCommand = Console.ReadLine()) != "END")
            {
                string[] commandParts = readCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = commandParts[0];
                string productName = commandParts[1];

                for (int i = 0; i < personsList.Count; i++)
                {
                    if(personsList[i].Name == personName)
                    {
                        for (int k = 0; k < productList.Count; k++)
                        {
                            if(productList[k].Name == productName)
                            {
                                if (personsList[i].CanAfordProduct(productList[k]))
                                {
                                    personsList[i].BuyProduct(productList[k]);
                                    Console.WriteLine($"{personsList[i].Name} bought {productList[k].Name}");
                                }
                                else
                                    Console.WriteLine($"{personsList[i].Name} can't afford {productList[k].Name}");
                            }
                        }
                    }
                }
            }
            foreach (Person person in personsList)
            {
                if(person.BagCount > 0)
                    Console.WriteLine(person.ToString());
                else Console.WriteLine($"{person.Name} - Nothing bought ");
            }
        }
    }
}
