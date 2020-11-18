namespace _06.FoodShortage
{
    public class Rebel : Citizen
    {
        public Rebel(string name, string age, string group) 
            : base(name, age, string.Empty, string.Empty)
        {
            this.Group = group;
        }
        public string Group { get; set; }

        public override int BuyFood() => this.Food += 5;
    }
}
