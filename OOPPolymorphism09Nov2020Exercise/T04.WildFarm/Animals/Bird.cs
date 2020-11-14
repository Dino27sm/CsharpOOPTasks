﻿namespace T04.WildFarm.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }
        public double WingSize { get; set; }
    }
}
