using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;

        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Service";
        }

        public string Name { get; }
        public int Happiness 
        {
            get => this.happiness;
            set => this.happiness = (value >= 0 && value <= 100) ? value
                : throw new ArgumentException(ExceptionMessages.InvalidHappiness);
        }

        public int Energy 
        {
            get => this.energy;
            set => this.energy = (value >= 0 && value <= 100) ? value
                : throw new ArgumentException(ExceptionMessages.InvalidEnergy);
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
