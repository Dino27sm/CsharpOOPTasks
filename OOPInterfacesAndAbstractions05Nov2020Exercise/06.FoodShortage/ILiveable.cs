namespace _06.FoodShortage
{
    public interface ILiveable : IIdentifyable
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
