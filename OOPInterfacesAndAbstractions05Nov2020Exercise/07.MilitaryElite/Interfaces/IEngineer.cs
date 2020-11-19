namespace _07.MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface IEngineer
    {
        public ICollection<IRepair> Repairs { get; set; }
    }
}
