using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
        private List<Character> characters;
        private List<Item> items;

        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = characterType switch
            {
                "Priest" => new Priest(name),
                "Warrior" => new Warrior(name),
                _ => throw new ArgumentException($"Invalid character type \"{characterType}\"!")
            };

            this.characters.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = itemName switch
            {
                "FirePotion" => new FirePotion(),
                "HealthPotion" => new HealthPotion(),
                _ => throw new ArgumentException($"Invalid item \"{itemName}\"!")
            };

            this.items.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            var getCharacter = this.characters.FirstOrDefault(x => x.Name == characterName);
            if (getCharacter == null)
                throw new ArgumentException($"Character {characterName} not found!");

            Item lastItem = this.items.LastOrDefault();
            if (lastItem == null)
                throw new InvalidOperationException($"No items left in pool!");

            getCharacter.Bag.AddItem(lastItem);
            this.items.RemoveAt(this.items.Count - 1);
            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var getCharacter = this.characters.FirstOrDefault(x => x.Name == characterName);
            if (getCharacter == null)
                throw new ArgumentException($"Character {characterName} not found!");

            var itemAffect = getCharacter.Bag.GetItem(itemName);
            getCharacter.UseItem(itemAffect);
            return $"{characterName} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.characters
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(y => y.Health))
            {
                string status = (item.IsAlive) ? "Alive" : "Dead";
                sb.AppendLine($"{item.Name} - HP: {item.Health}/{item.BaseHealth}, " +
                    $"AP: {item.Armor}/{item.BaseArmor}, Status: {status}");
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            var attacker = this.characters.FirstOrDefault(x => x.Name == attackerName);
            if (attacker == null)
                throw new ArgumentException($"Character {attackerName} not found!");

            var receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);
            if (receiver == null)
                throw new ArgumentException($"Character {receiverName} not found!");

            if (attacker.GetType().Name != nameof(Warrior))
                throw new ArgumentException($"{attacker.Name} cannot attack!");

            Warrior getAttacker = (Warrior)attacker;
            getAttacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{attackerName} attacks {receiverName} " +
                            $"for {attacker.AbilityPoints} hit points! " +
                            $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP " +
                            $"and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
                sb.AppendLine($"{receiver.Name} is dead!");

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            var healer = this.characters.FirstOrDefault(x => x.Name == healerName);
            if (healer == null)
                throw new ArgumentException($"Character {healerName} not found!");

            var healingReceiver = this.characters.FirstOrDefault(x => x.Name == healingReceiverName);
            if (healingReceiver == null)
                throw new ArgumentException($"Character {healingReceiverName} not found!");

            if (healer.GetType().Name != nameof(Priest))
                throw new ArgumentException($"{healerName} cannot heal!");

            Priest getHealer = (Priest)healer;
            getHealer.Heal(healingReceiver);

            return $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! " +
                $"{healingReceiver.Name} has {healingReceiver.Health} health now!";
        }
    }
}
