using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int diagonal1 = 0;
            int diagonal2 = 0;
            int[,] matrix = new int[n, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var list = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = list[k];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = i; k < matrix.GetLength(1); k++)
                {
                    diagonal1 += matrix[i, k];
                    break;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                    diagonal2 += matrix[i, matrix.GetLength(1) - 1 - i];
            } 
            Console.WriteLine(Math.Abs(diagonal1 - diagonal2));
        }
    }
}