using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private readonly List<IDye> dyes;

        public Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }

        public string Name 
        { 
            get => this.name;
            private set => this.name = string.IsNullOrWhiteSpace(value) 
                ? throw new ArgumentException("Bunny name cannot be null or empty.") 
                : value;
        }

        public int Energy
        {
            get => this.energy;
            protected set => this.energy = value < 0 ? 0 : value;
        }

        public ICollection<IDye> Dyes => this.dyes.AsReadOnly();

        public void AddDye(IDye dye)
        {
            if (dye != null)
                this.dyes.Add(dye);
        }

        public abstract void Work();
    }
}
