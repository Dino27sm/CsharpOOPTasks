namespace _06.FoodShortage
{
    public class Pet : ILiveable
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.Birthdate = birthDate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Id { get; set; }
    }
}
