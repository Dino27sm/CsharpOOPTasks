using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private const string name = "NameOne";
        private const int damage = 40;
        private const int hp = 40;

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase(40)]
        [TestCase(0)]
        public void WarriorConstructorShouldReturnObjectData(int hp1)
        {
            Warrior warriorOne = new Warrior(name, damage, hp1);
            
            Assert.That(warriorOne.Name, Is.EqualTo("NameOne"));
            Assert.That(warriorOne.Damage, Is.EqualTo(40));
            Assert.That(warriorOne.HP, Is.EqualTo(hp1));
        }

        [Test]
        public void WarriorPropertyShoulThrowExceptionIfSetNullName()
        {
            string name1 = null;
            string name2 = string.Empty;
            string name3 = "  ";

            Assert.Throws<ArgumentException>(() => new Warrior(name1, damage, hp));
            Assert.Throws<ArgumentException>(() => new Warrior(name2, damage, hp));
            Assert.Throws<ArgumentException>(() => new Warrior(name3, damage, hp));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void WarriorPropertyShoulThrowExceptionIfSetZeroDamage(int damage1)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage1, hp))
                .Message.Equals("Damage value should be positive!");
        }

        [Test]
        public void WarriorPropertyShoulThrowExceptionIfSetWrongHP()
        {
            int hp1 = -3;

            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp1));
        }

        [Test]
        public void WarriorOneAttackShouldGetStandoff()
        {
            Warrior warriorOne = new Warrior(name, damage, hp); //name = "NameOne"; damage = 30; hp = 40; MIN_ATTACK = 30;

            string name2 = "NameTwo";
            int damage2 = 40;
            int hp2 = 40;
            Warrior warriorTwo = new Warrior(name2, damage2, hp2);

            warriorOne.Attack(warriorTwo);

            Assert.That(warriorOne.HP, Is.EqualTo(0));
            Assert.That(warriorTwo.HP, Is.EqualTo(0));
        }

        [Test]
        public void WarriorOneAttackShouldWin()
        {
            Warrior warriorOne = new Warrior(name, damage, hp); //name = "NameOne"; damage = 40; hp = 40; MIN_ATTACK = 30;

            string name2 = "NameTwo";
            int damage2 = 40;
            int hp2 = 38;
            Warrior warriorTwo = new Warrior(name2, damage2, hp2);

            warriorOne.Attack(warriorTwo);

            Assert.That(warriorOne.HP, Is.EqualTo(0));
            Assert.That(warriorTwo.HP, Is.EqualTo(0));
        }

        [Test]
        [TestCase("NameOne", 40, 30)]
        [TestCase("NameOne", 40, 29)]
        public void WarriorOneAttackWithHpSmolerThanMinAttackShouldThrowException(string name1, int damage1, int hp1)
        {
            Warrior warriorOne = new Warrior(name1, damage1, hp1); //name = "NameOne"; damage = 40; hp = 40; MIN_ATTACK = 30;

            string name2 = "NameTwo";
            int damage2 = 40;
            int hp2 = 38;
            Warrior warriorTwo = new Warrior(name2, damage2, hp2);

            Assert.Throws<InvalidOperationException>(() => warriorOne.Attack(warriorTwo));
        }

        [Test]
        [TestCase("NameTwo", 40, 30)]
        [TestCase("NameTwo", 40, 29)]
        public void WarriorTwoAttackWithHpSmolerThanMinAttackShouldThrowException(string name2, int damage2, int hp2)
        {
            Warrior warriorOne = new Warrior(name, damage, hp); //name = "NameOne"; damage = 40; hp = 40; MIN_ATTACK = 30;
            Warrior warriorTwo = new Warrior(name2, damage2, hp2);

            Assert.Throws<InvalidOperationException>(() => warriorOne.Attack(warriorTwo));
        }

        [Test]
        public void WarriorOneAttackStrongerEnemyShouldThrowException()
        {
            Warrior warriorOne = new Warrior(name, damage, hp); //name = "NameOne"; damage = 40; hp = 40; MIN_ATTACK = 30;

            string name2 = "NameTwo";
            int damage2 = 41;
            int hp2 = 38;
            Warrior warriorTwo = new Warrior(name2, damage2, hp2);

            Assert.Throws<InvalidOperationException>(() => warriorOne.Attack(warriorTwo));
        }
    }
}