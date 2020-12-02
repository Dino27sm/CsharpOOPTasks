using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        Person[] personArray = new Person[17];

        [SetUp]
        public void Setup()
        {
            for (int i = 0; i < 17; i++)
            {
                personArray[i] = new Person(i, $"Name{i}");
            }
        }

        [Test]
        public void ConstructorAcceptsArrayOfUpto16Persons()
        {
            Person[] getNewArray = personArray.Take(16).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);

            Assert.That(aDatabase.Count, Is.EqualTo(16));
        }

        [Test]
        public void ConstructorCannotAcceptArrayWithMoreThan16Persons()
        {
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(personArray));
        }

        [Test]
        public void Add17thElementThrowsException()
        {
            Person[] getNewArray = personArray.Take(16).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);
            Person personToAdd = new Person(333, "Person_Name");

            Assert.Throws<InvalidOperationException>(() => aDatabase.Add(personToAdd));
        }

        [Test]
        public void AddElementNextFreeCell()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);
            Person personToAdd = new Person(333, "Person_Name");
            aDatabase.Add(personToAdd);
            Person findPerson = aDatabase.FindByUsername("Person_Name");

            Assert.That(findPerson.UserName, Is.EqualTo("Person_Name"));
        }

        [Test]
        public void AddDuplicatedNameThrowsException()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);
            Person personToAdd = new Person(30, "Name3");
            
            Assert.Throws<InvalidOperationException>(() => aDatabase.Add(personToAdd));
        }

        [Test]
        public void AddDuplicatedIdThrowsException()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);
            Person personToAdd = new Person(3, "Name30");

            Assert.Throws<InvalidOperationException>(() => aDatabase.Add(personToAdd));
        }

        [Test]
        public void RemoveElementOfArrayWithLastIndex()
        {
            Person[] getNewArray = personArray.Take(7).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);
            aDatabase.Remove();

            Assert.That(aDatabase.Count, Is.EqualTo(6));
        }

        [Test]
        public void RemoveElementFromEmtyArrayThrowsException()
        {
            Person[] getNewArray = new Person[0];

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);

            Assert.Throws<InvalidOperationException>(() => aDatabase.Remove());
        }

        [Test]
        public void FindNonExistingNameThrowsException()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);

            Assert.Throws<InvalidOperationException>(() => aDatabase.FindByUsername("Name33"));
        }

        [Test]
        public void FindEmptyNameThrowsException()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);

            Assert.Throws<ArgumentNullException>(() => aDatabase.FindByUsername(""));
        }

        [Test]
        public void FindNullNameThrowsException()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);

            Assert.Throws<ArgumentNullException>(() => aDatabase.FindByUsername(null));
        }


        [Test]
        public void FindCaseSensitiveNameThrowsException()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);

            Assert.Throws<InvalidOperationException>(() => aDatabase.FindByUsername("name3"));
        }

        [Test]
        public void FindNonExistingIdThrowsException()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);

            Assert.Throws<InvalidOperationException>(() => aDatabase.FindById(33));
        }

        [Test]
        public void FindNegativeIdThrowsException()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);

            Assert.Throws<ArgumentOutOfRangeException>(() => aDatabase.FindById(-3));
        }

        [Test]
        public void FindExistingNameById()
        {
            Person[] getNewArray = personArray.Take(10).ToArray();

            ExtendedDatabase aDatabase = new ExtendedDatabase(getNewArray);
            long id = 12_000_000_000;
            string name = "Name77";
            Person newPerson = new Person(id, name);
            aDatabase.Add(newPerson);
            Person getPersonById = aDatabase.FindById(id);

            Assert.That(getPersonById.UserName, Is.EqualTo(name));
        }
    }
}