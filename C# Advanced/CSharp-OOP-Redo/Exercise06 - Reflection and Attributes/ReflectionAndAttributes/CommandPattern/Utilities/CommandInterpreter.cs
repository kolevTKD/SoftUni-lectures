namespace CommandPattern.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args.Split(' ');
            string cmdName = inputArgs[0];
            string[] cmdArgs = inputArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(n => n.Name == $"{cmdName}Command");

            object commandObj = Activator.CreateInstance(commandType);

            MethodInfo[] methods = commandType.GetMethods();
            MethodInfo executeMethod = methods.FirstOrDefault(m => m.Name == "Execute");

            object methodObj = executeMethod.Invoke(commandObj, new object[] { cmdArgs });

            return methodObj.ToString();
        }
    }
}
