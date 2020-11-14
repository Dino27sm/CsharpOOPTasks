using System.Collections.Generic;
using System.Linq;

namespace T04.WildFarm.Animals
{
    public class Dog : Mammal
    {
        private const string DOG_SOUND = "Woof!";
        private const double DOG_WEIGHT_CORRECTION =  0.40;
        private string[] dogFood = { "meat" };
        
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.WeghtCorrection = DOG_WEIGHT_CORRECTION;
            this.MyFood = dogFood.ToArray();
        }
        public override double WeghtCorrection { get; set; }
        public override string[] MyFood { get; set; }
        public override string AnimalSound() => DOG_SOUND;
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, " +
                $"{this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
