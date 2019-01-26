using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
        }

        public void Run()
        {
            var input = reader.ReadLine().Split();

            while (true)
            {
                writer.WriteLine(commandParser.Parse(input));

                if (input[0] == "Exit")
                {
                    break;
                }

                input = reader.ReadLine().Split();
            }
        }
    }
}