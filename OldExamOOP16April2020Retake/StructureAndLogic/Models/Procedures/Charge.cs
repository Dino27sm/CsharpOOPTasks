﻿using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);

            robot.ProcedureTime -= procedureTime;
            robot.Happiness += 12;
            robot.Energy += 10;
        }
    }
}
