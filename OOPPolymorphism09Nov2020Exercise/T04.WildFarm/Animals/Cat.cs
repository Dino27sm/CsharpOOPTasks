using System.Linq;

namespace T04.WildFarm.Animals
{
    public class Cat : Feline
    {
        private const string CAT_SOUND = "Meow";
        private const double CAT_WEIGHT_CORRECTION = 0.30;
        private string[] catFood = { "meat", "vegetable" };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.WeghtCorrection = CAT_WEIGHT_CORRECTION;
            this.MyFood = catFood.ToArray();
        }
        public override double WeghtCorrection { get; set; }
        public override string[] MyFood { get; set; }
        public override string AnimalSound() => CAT_SOUND;
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, " +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
