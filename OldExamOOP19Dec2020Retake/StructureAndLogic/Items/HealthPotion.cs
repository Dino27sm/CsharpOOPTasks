
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            if (character.Health + 20 > character.BaseHealth)
                character.Health = character.BaseHealth;
            else
                character.Health += 20;
        }
    }
}
