﻿using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    class Work : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness += 12;
            robot.Energy -= 6;
            this.Robots.Add(robot);
        }
    }
}
