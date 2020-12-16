using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        public Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name 
        { 
            get => this.name;
            private set => this.name = !string.IsNullOrWhiteSpace(value) ? value
                : throw new ArgumentException(ExceptionMessages.InvalidGunName);
        }
        public int BulletsCount 
        { 
            get => this.bulletsCount;
            protected set => this.bulletsCount = value >= 0 ? value 
                : throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
        }

        public abstract int Fire();
    }
}
