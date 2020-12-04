using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private const int MIN_ATTACK_HP = 30;

        private const string name1 = "NameOne";
        private const int damage1 = 40;
        private const int hp1 = 40;

        private const string name2 = "NameTwo";
        private const int damage2 = 39;
        private const int hp2 = 38;

        Warrior warriorOne = null;
        Warrior warriorTwo = null;

        Arena arenaOne = null;

        [SetUp]
        public void Setup()
        {
            warriorOne = new Warrior(name1, damage1, hp1);
            warriorTwo = new Warrior(name2, damage2, hp2);
            arenaOne = new Arena();
        }

        [Test]
        public void ArenaConstructorShouldCreateEmptyListOfWarriors()
        {
            Assert.That(arenaOne.Warriors.Count, Is.EqualTo(0));
        }

        [Test]
        public void ArenaEnrollMetodShouldEnrollWarriors()
        {
            arenaOne.Enroll(warriorOne);
            arenaOne.Enroll(warriorTwo);
            
            Assert.That(arenaOne.Warriors.Count, Is.EqualTo(2));
        }

        [Test]
        public void ArenaEnrollMetodShouldThrowExceptionIfEnrollDuplicatedWarriorName()
        {
            arenaOne.Enroll(warriorOne);
            arenaOne.Enroll(warriorTwo);
            Warrior warriorTemp = new Warrior("NameOne", damage2, hp2);

            Assert.Throws<InvalidOperationException>(() => arenaOne.Enroll(warriorTemp));
        }

        [Test]
        public void ArenaFightMethodShouldThrowExceptionIfFighterNotEnrolled()
        {
            arenaOne.Enroll(warriorOne);
            arenaOne.Enroll(warriorTwo);

            Assert.Throws<InvalidOperationException>(() => arenaOne.Fight(name1, "NotEnroled"));
        }

        [Test]
        public void ArenaFightMethodShouldAllowFighting()
        {
            arenaOne.Enroll(warriorOne);
            arenaOne.Enroll(warriorTwo);

            arenaOne.Fight(warriorOne.Name, warriorTwo.Name);

            Assert.That(warriorOne.HP, Is.EqualTo(1));
            Assert.That(warriorTwo.HP, Is.EqualTo(0));
        }
    }
}
