using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double BASE_HEALTH = 50;
        private const double BASE_ARMOR = 25;
        private const double ABILITY_POINTS = 40;

        public Priest(string name)
            : base(name)
        {
            this.BaseHealth = BASE_HEALTH;
            this.Health = BASE_HEALTH;

            this.BaseArmor = BASE_ARMOR;
            this.Armor = BASE_ARMOR;

            this.AbilityPoints = ABILITY_POINTS;
            this.Bag = new Backpack();
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);

            double healValue = character.Health + this.AbilityPoints;

            if (healValue > character.BaseHealth)
                character.Health = character.BaseHealth;
            else
                character.Health += this.AbilityPoints;
        }
    }
}
