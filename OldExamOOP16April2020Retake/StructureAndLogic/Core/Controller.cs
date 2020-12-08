namespace RobotService.Core
{
    using RobotService.Core.Contracts;
    using RobotService.Models.Garages;
    using RobotService.Models.Garages.Contracts;
    using RobotService.Models.Procedures;
    using RobotService.Models.Procedures.Contracts;
    using RobotService.Models.Robots;
    using RobotService.Models.Robots.Contracts;
    using RobotService.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Controller : IController
    {
        private IGarage garage;
        private Dictionary<string, List<IRobot>> dictProcedure;

        public Controller()
        {
            this.garage = new Garage();
            this.dictProcedure = new Dictionary<string, List<IRobot>>();

            dictProcedure["Charge"] = new List<IRobot>();
            dictProcedure["Chip"] = new List<IRobot>();
            dictProcedure["Polish"] = new List<IRobot>();
            dictProcedure["Rest"] = new List<IRobot>();
            dictProcedure["TechCheck"] = new List<IRobot>();
            dictProcedure["Work"] = new List<IRobot>();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;
            if (robotType == "HouseholdRobot")
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            else if (robotType == "PetRobot")
                robot = new PetRobot(name, energy, happiness, procedureTime);
            else if (robotType == "WalkerRobot")
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            else
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));

            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, robot.Name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            IRobot robot = this.garage.Robots[robotName];
            IProcedure chip = new Chip();
            chip.DoService(robot, procedureTime);
            this.dictProcedure["Chip"].Add(robot);

            return string.Format(OutputMessages.ChipProcedure, robot.Name);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            IRobot robot = this.garage.Robots[robotName];
            IProcedure techCheck = new TechCheck();
            techCheck.DoService(robot, procedureTime);
            this.dictProcedure["TechCheck"].Add(robot);

            return string.Format(OutputMessages.TechCheckProcedure, robot.Name);
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            IRobot robot = this.garage.Robots[robotName];
            IProcedure rest = new Rest();
            rest.DoService(robot, procedureTime);
            this.dictProcedure["Rest"].Add(robot);

            return string.Format(OutputMessages.RestProcedure, robot.Name);
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            IRobot robot = this.garage.Robots[robotName];
            IProcedure charge = new Charge();
            charge.DoService(robot, procedureTime);
            this.dictProcedure["Charge"].Add(robot);

            return string.Format(OutputMessages.ChargeProcedure, robot.Name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            IRobot robot = this.garage.Robots[robotName];
            IProcedure polish = new Polish();
            polish.DoService(robot, procedureTime);
            this.dictProcedure["Polish"].Add(robot);

            return string.Format(OutputMessages.PolishProcedure, robot.Name);
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            IRobot robot = this.garage.Robots[robotName];
            IProcedure work = new Work();
            work.DoService(robot, procedureTime);
            this.dictProcedure["Work"].Add(robot);

            return string.Format(OutputMessages.WorkProcedure, robot.Name, procedureTime);
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));

            IRobot robot = this.garage.Robots[robotName];
            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string History(string procedureType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{procedureType}");

            foreach (var item in this.dictProcedure[procedureType])
            {
                sb.AppendLine($"{item.ToString()}");
            }
            return sb.ToString().Trim();
        }
    }
}
