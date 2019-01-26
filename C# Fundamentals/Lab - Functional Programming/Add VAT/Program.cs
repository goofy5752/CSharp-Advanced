using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] priceWithVAT = Console.ReadLine().Split(", ").Select(double.Parse).ToArray();
            for (int i = 0; i < priceWithVAT.Length; i++)
            {
                Console.WriteLine($"{(priceWithVAT[i] * 1.2):F2}");
            }
        }
    }
}