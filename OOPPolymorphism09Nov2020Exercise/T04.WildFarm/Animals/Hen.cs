using System.Linq;

namespace T04.WildFarm.Animals
{
    public class Hen : Bird
    {
        private const string HEN_SOUND = "Cluck";
        private const double HEN_WEIGHT_CORRECTION = 0.35;
        private string[] henFood = { "vegetable", "fruit", "seeds", "meat" };

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.WeghtCorrection = HEN_WEIGHT_CORRECTION;
            this.MyFood = henFood.ToArray();
        }
        public override double WeghtCorrection { get; set; }
        public override string AnimalSound() => HEN_SOUND;
        public override string[] MyFood { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, " +
                $"{this.Weight}, {this.FoodEaten}]";
        }
    }
}
