namespace T04.WildFarm.Animals
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
        public virtual string LivingRegion { get; set; }
    }
}
