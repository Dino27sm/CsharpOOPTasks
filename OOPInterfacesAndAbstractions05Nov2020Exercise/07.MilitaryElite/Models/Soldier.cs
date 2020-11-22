namespace _07.MilitaryElite
{
    using _07.MilitaryElite.Interfaces;

    public abstract class Soldier : ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirsName = firstName;
            this.LastName = lastName;
        }
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
    }
}
