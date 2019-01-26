namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.IO;
    using IO.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.PortableExecutable;

    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setController)
        {
            this.reader = new Reader();
            this.writer = new Writer();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine();

                if (input == "END")
                    break;

                try
                {
                    string.Intern(input);

                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            //var end = this.festivalController;

            this.writer.WriteLine("Results:");
            //this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var parts = input.Split(" ".ToCharArray().First());

            var first = parts[0];
            var args = parts.Skip(1).ToArray();

            if (first == "LetsRock")
            {
                //var sets = this.setController.PerformSets();
                //return sets;
            }

            //var festivalcontrolfunction = this.festivalController.GetType()
                //.GetMethods()
                //.FirstOrDefault(x => x.Name == first);

            string a;

            try
            {
                //a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { args });
            }
            catch (TargetInvocationException up)
            {
                throw up; // ha ha
            }

            return null;
        }
    }
}