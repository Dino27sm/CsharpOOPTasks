using CommandPattern.Core.Contracts;
using CommandPattern.Core.Commands;
using System;
using System.Reflection;
using System.Linq;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandLine = args.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string[] arguments = commandLine.Skip(1).ToArray();
            string commanName = commandLine[0];

            Type type = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name.StartsWith(commanName));

            if (type == null)
                throw new ArgumentException("Invalid command type!");

            ICommand command = Activator.CreateInstance(type) as ICommand;

            if (command == null)
                throw new ArgumentException("Invalid command type!");

            return command.Execute(arguments);
        }
    }
}
