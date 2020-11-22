namespace _07.MilitaryElite
{
    using _07.MilitaryElite.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.PrivatesList = privates;
        }

        public ICollection<IPrivate> PrivatesList { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirsName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Privates:");
            foreach (var privateOne in this.PrivatesList)
            {
                sb.AppendLine($"  {privateOne.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
