using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = string.IsNullOrWhiteSpace(value) 
                ? throw new ArgumentException("Name cannot be null or whitespace!")
                : value;
        }

        public double BaseHealth { get; protected set; }

        public double Health
        {
            get => this.health;
            set 
            {
                if (value >= 0 && value <= this.BaseHealth)
                    this.health = value;
            }
        }

        public double BaseArmor { get; protected set; }

        public double Armor
        {
            get => this.armor;
            protected set
            {
                if (value >= 0)
                    this.armor = value;
            }
        }

        public double AbilityPoints { get; protected set; }

        public Bag Bag { get; protected set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            var reducedArmor = this.Armor - hitPoints;
            if (reducedArmor < 0)
            {
                this.Armor = 0;
                if (this.Health + reducedArmor <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
                else
                    this.Health += reducedArmor;
            }
            else
                this.Armor -= hitPoints;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}