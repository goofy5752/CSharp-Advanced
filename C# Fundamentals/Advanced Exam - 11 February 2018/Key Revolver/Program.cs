using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsReader = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] locksReader = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int intelligence = int.Parse(Console.ReadLine());
            var locks = new Queue<int>();
            var bullets = new Stack<int>();
            for (int i = 0; i < bulletsReader.Length; i++)
            {
                bullets.Push(bulletsReader[i]);
            }
            for (int i = 0; i < locksReader.Length; i++)
            {
                locks.Enqueue(locksReader[i]);
            }
            int bulletCounter = 0;
            while (true)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    bullets.Pop();
                    bulletCounter++;
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                    if (bulletCounter % gunBarrel == 0 && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                    }
                    if (bullets.Count == 0 && locks.Count > 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        break;
                    }
                    if (locks.Count == 0)
                    {
                        Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (bulletCounter * pricePerBullet)}");
                        break;
                    }

                }
                else
                {
                    bullets.Pop();
                    bulletCounter++;
                    Console.WriteLine("Ping!");
                }
                if (bullets.Count == 0 && locks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (bulletCounter * pricePerBullet)}");
                    break;
                }
            }
        }
    }
}