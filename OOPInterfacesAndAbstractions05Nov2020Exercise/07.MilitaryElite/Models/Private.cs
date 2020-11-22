namespace _07.MilitaryElite
{
    using _07.MilitaryElite.Interfaces;

    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {this.FirsName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}";
        }
    }
}
