using System.Linq;

namespace T04.WildFarm.Animals
{
    public class Owl : Bird
    {
        private const string OWL_SOUND = "Hoot Hoot";
        private const double OWL_WEIGHT_CORRECTION = 0.25;
        private string[] owlFood = { "meat" };

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.WeghtCorrection = OWL_WEIGHT_CORRECTION;
            this.MyFood = owlFood.ToArray();
        }
        public override double WeghtCorrection { get; set; }
        public override string AnimalSound() => OWL_SOUND;
        public override string[] MyFood { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, " +
                $"{this.Weight}, {this.FoodEaten}]";
        }
    }
}
