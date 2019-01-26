namespace TheTankGame.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }

        public void Run()
        {
            var input = reader.ReadLine().Split().ToList();

            while (input[0] != "Terminate")
            {
                Console.WriteLine(commandInterpreter.ProcessInput(input));
                input = reader.ReadLine().Split().ToList();
            }
            Console.WriteLine(commandInterpreter.ProcessInput(input));
        }
    }
}