using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Linq;
using RobotService.Models.Procedures;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private IProcedure[] procedures = { new Charge(), new Chip(), new Polish(), new Rest(), new TechCheck(), new Work() };

        public Controller()
        {
            this.garage = new Garage();
        }

        public string History(string procedureType)
        {
            IProcedure procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == procedureType);
            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = robotType switch
            {
                "HouseholdRobot" => new HouseholdRobot(name, energy, happiness, procedureTime),
                "PetRobot" => new PetRobot(name, energy, happiness, procedureTime),
                "WalkerRobot" => new WalkerRobot(name, energy, happiness, procedureTime),
                _ => throw new ArgumentException($"{robotType} type doesn't exist"),
            };

            this.garage.Manufacture(robot);
            return string.Format(OutputMessages.RobotManufactured, robot.Name);
        }

        public string Charge(string robotName, int procedureTime)
        {
            procedures[0].DoService(GetExistingRobot(robotName), procedureTime);
            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            procedures[1].DoService(GetExistingRobot(robotName), procedureTime);
            return $"{robotName} had chip procedure";
        }

        public string Polish(string robotName, int procedureTime)
        {
            procedures[2].DoService(GetExistingRobot(robotName), procedureTime);
            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            procedures[3].DoService(GetExistingRobot(robotName), procedureTime);
            return $"{robotName} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetExistingRobot(robotName);
            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
                return $"{ownerName} bought robot with chip";
            else
                return $"{ownerName} bought robot without chip";
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            procedures[4].DoService(GetExistingRobot(robotName), procedureTime);
            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            procedures[5].DoService(GetExistingRobot(robotName), procedureTime);
            return $"{robotName} was working for {procedureTime} hours";
        }

        private IRobot GetExistingRobot(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
                throw new ArgumentException($"Robot {robotName} does not exist");

            return this.garage.Robots[robotName];
        }
    }
}
