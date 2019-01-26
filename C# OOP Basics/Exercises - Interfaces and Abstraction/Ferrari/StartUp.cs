using System;

namespace FerrariProj
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            IFerrari ferrari = new Ferrari(name);
            Console.WriteLine(ferrari.ToString());
        }
    }
}