namespace _07.MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface ICommando
    {
        public ICollection<IMission> Missions { get; set; }
    }
}
