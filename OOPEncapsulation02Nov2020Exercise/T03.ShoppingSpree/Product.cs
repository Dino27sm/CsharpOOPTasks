using System;

namespace T03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;

        internal Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        internal string Name 
        {
            get => this.name;
            set => this.name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Name cannot be empty");
        }
        internal double Cost 
        {
            get => this.cost;
            set => this.cost = value >= 0 ? value : throw new ArgumentException("Money cannot be negative");
        }
    }
}
