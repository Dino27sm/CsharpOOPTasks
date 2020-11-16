namespace _05.BirthdayCelebrations
{
    public interface ILiveable : IIdentifyable
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
