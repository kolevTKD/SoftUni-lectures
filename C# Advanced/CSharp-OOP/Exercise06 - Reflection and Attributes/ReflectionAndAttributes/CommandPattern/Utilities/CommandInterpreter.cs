using CommandPattern.Utilities.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Utilities
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = cmdArgs[0];
            string[] invokeArgs = cmdArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type intendedCmdType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (intendedCmdType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            MethodInfo executeInstance = intendedCmdType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "Execute");

            if (executeInstance ==  null)
            {
                throw new InvalidOperationException("Command does not implement required pattern. Try implementing ICommand interface instead!");
            }

            object cmdInstance = Activator.CreateInstance(intendedCmdType);

            return (string)executeInstance.Invoke(cmdInstance, new object[] { invokeArgs });

        }
    }
}
