using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[n[0], n[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var list = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = list[k];
                }
            }
            int totalSum = 0;
            int[,] largestRectangularMatrix = new int[3, 3];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    largestRectangularMatrix[i, k] = matrix[i, k];
                    largestRectangularMatrix[i, k + 1] = matrix[i, k + 1];
                    largestRectangularMatrix[i, k + 2] = matrix[i, k + 2];
                    totalSum += matrix[i, k];
                }
            }
            for (int i = 0; i < largestRectangularMatrix.GetLength(0); i++)
            {
                for (int k = 0; k < largestRectangularMatrix.GetLength(1); k++)
                {
                    Console.Write(largestRectangularMatrix[i,k] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}