using System.Linq;

namespace T04.WildFarm.Animals
{
    public class Mouse : Mammal
    {
        private const string MOUSE_SOUND = "Squeak";
        private const double MOUSE_WEIGHT_CORRECTION = 0.10;
        private string[] mouseFood = { "vegetable", "fruit" };

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.WeghtCorrection = MOUSE_WEIGHT_CORRECTION;
            this.MyFood = mouseFood.ToArray();
        }
        public override double WeghtCorrection { get; set; }
        public override string AnimalSound() => MOUSE_SOUND;
        public override string[] MyFood { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, " +
                $"{this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
