namespace _07.MilitaryElite
{
    using _07.MilitaryElite.Enumerators;
    using _07.MilitaryElite.Interfaces;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, CorpsEnumerator corpsEnum) 
            : base(id, firstName, lastName, salary)
        {
            this.CorpsEnumerator = corpsEnum;
        }

        public CorpsEnumerator CorpsEnumerator { get; }
    }
}
