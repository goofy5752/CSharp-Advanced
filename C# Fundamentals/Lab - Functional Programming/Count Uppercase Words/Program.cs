using System;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < input.Length; i++)
            {
                foreach (var item in input[i])
                {
                    if (char.IsUpper(item))
                    {
                        Console.WriteLine(input[i]);
                        break;
                    }
                }
            }
        }
    }
}