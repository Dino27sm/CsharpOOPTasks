namespace _04.BorderControl
{
    public class Citizen : ILiveable
    {
        public Citizen(string name, string age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Id { get; set; }
    }
}
