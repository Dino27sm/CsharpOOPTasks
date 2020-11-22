namespace _07.MilitaryElite
{
    using _07.MilitaryElite.Enumerators;
    using _07.MilitaryElite.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary,
            CorpsEnumerator corpsEnum, ICollection<IRepair> repairs) 
            : base(id, firstName, lastName, salary, corpsEnum)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirsName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.CorpsEnumerator}");
            sb.AppendLine($"Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
