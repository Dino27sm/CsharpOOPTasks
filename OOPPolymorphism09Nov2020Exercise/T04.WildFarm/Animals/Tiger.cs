using System.Buffers.Text;
using System.Linq;

namespace T04.WildFarm.Animals
{
    public class Tiger : Feline
    {
        private const string TIGER_SOUND = "ROAR!!!";
        private const double TIGER_WEIGHT_CORRECTION = 1.0;
        private string[] tigerFood = { "meat" };

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.WeghtCorrection = TIGER_WEIGHT_CORRECTION;
            this.MyFood = tigerFood.ToArray();
        }
        public override double WeghtCorrection { get; set; }
        public override string AnimalSound() => TIGER_SOUND;
        public override string[] MyFood { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, " +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
