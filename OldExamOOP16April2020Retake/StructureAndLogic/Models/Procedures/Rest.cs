using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);

            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= 3;
            robot.Energy += 10;
        }
    }
}
