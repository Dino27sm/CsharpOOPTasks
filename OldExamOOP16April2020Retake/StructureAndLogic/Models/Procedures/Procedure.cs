namespace RobotService.Models.Procedures
{
    using System.Collections.Generic;
    using System.Text;
    using RobotService.Models.Procedures.Contracts;
    using RobotService.Models.Robots.Contracts;

    public abstract class Procedure : IProcedure
    {

        public Procedure()
        {
            this.Robots = new List<IRobot>();
        }
        protected virtual List<IRobot> Robots { get; set; }

        public abstract void DoService(IRobot robot, int procedureTime);

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
