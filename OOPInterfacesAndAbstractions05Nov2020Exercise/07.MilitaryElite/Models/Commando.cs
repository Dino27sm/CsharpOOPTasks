namespace _07.MilitaryElite
{
    using _07.MilitaryElite.Enumerators;
    using _07.MilitaryElite.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary,
            CorpsEnumerator corpsEnum, ICollection<IMission> missions) 
            : base(id, firstName, lastName, salary, corpsEnum)
        {
            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirsName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.CorpsEnumerator}");
            sb.AppendLine($"Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
