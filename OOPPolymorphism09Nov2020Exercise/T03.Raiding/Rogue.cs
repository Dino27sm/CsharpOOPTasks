namespace T03.Raiding
{
    public class Rogue : BaseHero
    {
        private const int ROGUE_POWER = 80;

        public Rogue(string name) : base(name, ROGUE_POWER) { }

        public override string CastAbility()
            => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
