namespace TheTankGame.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters.RemoveAt(0);
            object result;

            Type testType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x=> x.Name == "TankManager");
            var testInstance = Activator.CreateInstance(testType, tankManager);

            MethodInfo toInvoke = testType.GetMethod(command);
            result = toInvoke.Invoke(testInstance, inputParameters.ToArray());

            return result.ToString();
        }
    }
}