using System;
using System.Collections.Generic;

namespace T03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<string> bag;

        internal Person(string namePerson, double money)
        {
            this.Name = namePerson;
            this.Money = money;
            this.bag = new List<string>();
        }
        internal int BagCount => this.bag.Count;
        internal string Name
        {
            get => this.name;
            set => this.name = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Name cannot be empty");
        }
        internal double Money
        {
            get => this.money;
            set => this.money = value >= 0 ? value : throw new ArgumentException("Money cannot be negative");
        }

        internal bool CanAfordProduct(Product productObject)
        {
            return (this.money - productObject.Cost >= 0);
        }

        internal void BuyProduct(Product productObject)
        {
            this.bag.Add(productObject.Name);
            this.Money -= productObject.Cost;
        }

        public override string ToString()
        {
            return $"{this.Name} - {string.Join(", ", this.bag)}";
        }
    }
}
