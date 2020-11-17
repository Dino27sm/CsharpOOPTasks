namespace _06.FoodShortage
{
    public class Citizen : ILiveable, IBuyer
    {
        public Citizen(string name, string age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; } = 0;

        public virtual int BuyFood() => this.Food += 10;
    }
}
