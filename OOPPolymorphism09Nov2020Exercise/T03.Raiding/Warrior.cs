namespace T03.Raiding
{
    public class Warrior : BaseHero
    {
        private const int ROGUE_POWER = 100;

        public Warrior(string name) : base(name, ROGUE_POWER) { }

        public override string CastAbility()
            => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
