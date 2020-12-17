using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
            this.Capacity = 10;
        }

        private int Capacity { get; set; }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;
        
        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count >= this.Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);

            if(this.robots.Any(x => x.Value.Name == robot.Name))
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            IRobot getRobot = this.robots.Values.FirstOrDefault(x => x.Name == robotName);
            if (getRobot == null)
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            getRobot.Owner = ownerName;
            getRobot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
