using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            var hash = new HashSet<string>();
            while (input[0] != "END")
            {
                if (input[0] == "IN")
                {
                    hash.Add(input[1]);
                }
                else
                {
                    hash.Remove(input[1]);
                }
                input = Console.ReadLine().Split(", ");
            }
            if (hash.Count > 0)
            {
                foreach (var item in hash)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}