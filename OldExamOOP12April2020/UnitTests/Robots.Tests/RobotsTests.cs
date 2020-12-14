namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Robot_Constructor_Initial()
        {
            Robot r1 = new Robot("rname", 100);

            Assert.That(r1.Name, Is.EqualTo("rname"));
            Assert.That(r1.Battery, Is.EqualTo(100));
            Assert.That(r1.MaximumBattery, Is.EqualTo(100));
        }

        [Test]
        public void Robot_Property_Correct_Change()
        {
            Robot r1 = new Robot("rname", 100);
            r1.Battery = 80;
            r1.Name = "Mname";

            Assert.That(r1.Name, Is.EqualTo("Mname"));
            Assert.That(r1.Battery, Is.EqualTo(80));
        }

        [Test]
        public void RobotMng_Constructor_Initial()
        {
            RobotManager rm1 = new RobotManager(70);

            Assert.That(rm1.Capacity, Is.EqualTo(70));
            Assert.That(rm1.Count, Is.EqualTo(0));
        }

        [Test]
        public void RobotMng_Constructor_Initial_Zero_Allowed()
        {
            RobotManager rm1 = new RobotManager(0);

            Assert.That(rm1.Capacity, Is.EqualTo(0));
            Assert.That(rm1.Count, Is.EqualTo(0));
        }

        [Test]
        public void RobotMng_Constructor_Negative_Capacity_Throw_Excep()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-8));
        }

        [Test]
        public void Add_Robot_Add_OneRobot_Allowed()
        {
            Robot r1 = new Robot("rname", 100);
            RobotManager rm1 = new RobotManager(6);

            rm1.Add(r1);

            Assert.That(rm1.Capacity, Is.EqualTo(6));
            Assert.That(rm1.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_Robot_Add_MoreRobots_Allowed()
        {
            Robot r1 = new Robot("name1", 100);
            Robot r2 = new Robot("name2", 200);
            RobotManager rm1 = new RobotManager(6);

            rm1.Add(r1);
            rm1.Add(r2);

            Assert.That(rm1.Capacity, Is.EqualTo(6));
            Assert.That(rm1.Count, Is.EqualTo(2));
        }

        [Test]
        public void Add_Robot_If_Not_Capacity_Throw_Excep()
        {
            Robot r1 = new Robot("rname", 100);
            RobotManager rm1 = new RobotManager(1);

            rm1.Add(r1);

            Assert.Throws<InvalidOperationException>(() => rm1.Add(new Robot("Rname", 200)));
        }

        [Test]
        public void Add_Robot_With_Duplicated_Name_Throw_Excep()
        {
            Robot r1 = new Robot("name", 100);
            RobotManager rm1 = new RobotManager(3);

            rm1.Add(r1);

            Assert.Throws<InvalidOperationException>(() => rm1.Add(new Robot("name", 200)));
        }

        [Test]
        public void Remove_Robot_Allowed()
        {
            Robot r1 = new Robot("name1", 100);
            Robot r2 = new Robot("name2", 200);
            RobotManager rm1 = new RobotManager(3);

            rm1.Add(r1);
            rm1.Add(r2);

            rm1.Remove("name2");

            Assert.That(rm1.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_NonExisting_Robot_Throw_Excep()
        {
            Robot r1 = new Robot("name1", 100);
            Robot r2 = new Robot("name2", 200);
            RobotManager rm1 = new RobotManager(3);

            rm1.Add(r1);
            rm1.Add(r2);

            Assert.Throws<InvalidOperationException>(() => rm1.Remove("name3"));
        }

        [Test]
        public void Work_Robot_Allowed()
        {
            Robot r1 = new Robot("name1", 100);
            Robot r2 = new Robot("name2", 200);
            RobotManager rm1 = new RobotManager(3);

            rm1.Add(r1);
            rm1.Add(r2);
            rm1.Work("name1", "job", 60);
            rm1.Work("name2", "job", 120);

            Assert.That(r1.Battery, Is.EqualTo(40));
            Assert.That(r2.Battery, Is.EqualTo(80));
        }

        [Test]
        public void Work_Robot_Not_found_Throw_Ex()
        {
            Robot r1 = new Robot("name1", 100);
            Robot r2 = new Robot("name2", 200);
            RobotManager rm1 = new RobotManager(3);

            rm1.Add(r1);
            rm1.Add(r2);
            rm1.Work("name1", "job", 60);

            Assert.Throws<InvalidOperationException>(() => rm1.Work("name3", "job", 120));
        }

        [Test]
        public void Work_Robot_Not_BattUsage_Throw_Ex()
        {
            Robot r1 = new Robot("name1", 100);
            Robot r2 = new Robot("name2", 200);
            RobotManager rm1 = new RobotManager(3);

            rm1.Add(r1);
            rm1.Add(r2);
            rm1.Work("name1", "job", 60);

            Assert.Throws<InvalidOperationException>(() => rm1.Work("name2", "job", 220));
        }

        [Test]
        public void Charge_Robot_Not_Found_Throw_Ex()
        {
            Robot r1 = new Robot("name1", 100);
            Robot r2 = new Robot("name2", 200);
            RobotManager rm1 = new RobotManager(3);

            rm1.Add(r1);
            rm1.Add(r2);

            Assert.Throws<InvalidOperationException>(() => rm1.Charge("name3"));
        }

        [Test]
        public void Charge_Robot_Allowed()
        {
            Robot r1 = new Robot("name1", 100);
            RobotManager rm1 = new RobotManager(3);

            rm1.Add(r1);
            rm1.Work("name1", "job", 60);

            rm1.Charge("name1");

            Assert.That(r1.Battery, Is.EqualTo(100));
        }
    }
}
