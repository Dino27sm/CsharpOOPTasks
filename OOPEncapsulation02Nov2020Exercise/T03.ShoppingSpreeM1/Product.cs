namespace T03.ShoppingSpreeM1
{
    using System;

    public class Product
    {
        private string name;
        private decimal cost;

        internal Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        internal string Name
        {
            get => this.name;
            set => this.name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Name cannot be empty");
        }
        internal decimal Cost
        {
            get => this.cost;
            set => this.cost = value >= 0M ? value : throw new ArgumentException("Money cannot be negative");
        }
    }
}
