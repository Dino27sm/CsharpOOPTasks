using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double BASE_HEALTH = 100;
        private const double BASE_ARMOR = 50;
        private const double ABILITY_POINTS = 40;

        public Warrior(string name)
            : base(name)
        {
            this.BaseHealth = BASE_HEALTH;
            this.Health = BASE_HEALTH;

            this.BaseArmor = BASE_ARMOR;
            this.Armor = BASE_ARMOR;

            this.AbilityPoints = ABILITY_POINTS;
            this.Bag = new Satchel();
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);

            if (this.Name == character.Name)
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
