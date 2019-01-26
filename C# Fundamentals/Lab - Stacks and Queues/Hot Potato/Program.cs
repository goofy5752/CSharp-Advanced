using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] childrens = Console.ReadLine().Split();
            Queue<string> children = new Queue<string>();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < childrens.Length; i++)
            {
                children.Enqueue(childrens[i]);
            }

            while (children.Count > 1)
            {
                for (int i = 0; i < counter - 1; i++)
                {
                    children.Enqueue(children.Dequeue());
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}