using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name 
        { 
            get => this.name; 
            private set => this.name = string.IsNullOrWhiteSpace(value) 
                ? throw new ArgumentException("Egg name cannot be null or empty.") 
                : value; 
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set => this.energyRequired = value < 0 ? 0 : value;
        }

        public void GetColored() => this.EnergyRequired -= 10;
        public bool IsDone() => this.energyRequired == 0;
    }
}
