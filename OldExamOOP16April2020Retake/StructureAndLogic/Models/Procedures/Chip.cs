using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            
            if (robot.IsChipped)
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));

            robot.ProcedureTime -= procedureTime;
            robot.IsChipped = true;
            robot.Happiness -= 5;
        }
    }
}
