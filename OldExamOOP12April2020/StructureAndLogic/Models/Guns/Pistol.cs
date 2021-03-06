﻿namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private int bulletRate = 1;

        public Pistol(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()  //Check for available bullets - if there are any -> shoots with given rate !!!
        {
            if (this.BulletsCount - bulletRate >= 0)
            {
                this.BulletsCount -= bulletRate;
                return bulletRate;
            }
            else
            {
                int remainBullets = this.BulletsCount;
                this.BulletsCount = 0;
                return remainBullets;
            }
        }
    }
}
