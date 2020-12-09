namespace RobotService.Models.Garages
{
    using RobotService.Models.Garages.Contracts;
    using RobotService.Models.Robots.Contracts;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System;
    using RobotService.Utilities.Messages;

    public class Garage : IGarage
    {
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
            this.Capacity = 10;
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;
        public int Capacity  { get;}

        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count >= this.Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);

            if (this.robots.ContainsKey(robot.Name))
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if(!this.robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            this.robots[robotName].Owner = ownerName;
            this.robots[robotName].IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
