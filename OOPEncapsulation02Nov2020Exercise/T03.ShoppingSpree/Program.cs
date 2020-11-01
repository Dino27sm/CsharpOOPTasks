using System;
using System.Collections.Generic;

namespace T03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> personData = new Dictionary<string, Person>();
            Dictionary<string, Product> productData = new Dictionary<string, Product>();

            string[] readPersons = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string[] readProducts = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < readPersons.Length; i++)
            {
                string[] infoParts = readPersons[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                string personName = infoParts[0];
                double money = double.Parse(infoParts[1]);
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
                if (!personData.ContainsKey(personName))
                    personData.Add(personName, newPerson);
            }

            for (int i = 0; i < readProducts.Length; i++)
            {
                string[] infoParts = readProducts[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                string productName = infoParts[0];
                double price = double.Parse(infoParts[1]);
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
                if (!productData.ContainsKey(productName))
                    productData.Add(productName, newProduct);
            }

            string instructions = "";
            while((instructions = Console.ReadLine()) != "END")
            {
                string[] commandParts = instructions.Split();
                string personName = commandParts[0];
                string productName = commandParts[1];
                if (personData.ContainsKey(personName) && productData.ContainsKey(productName))
                {
                    if (personData[personName].CanAfordProduct(productData[productName]))
                    {
                        personData[personName].BuyProduct(productData[productName]);
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    else
                        Console.WriteLine($"{personName} can't afford {productName}");
                }
            }
            foreach (var item in personData)
            {
                if(item.Value.BagCount > 0)
                    Console.WriteLine(item.Value.ToString());
                else Console.WriteLine($"{item.Value.Name} - Nothing bought ");
            }
        }
    }
}
