using System;
using System.Linq;

namespace _2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[n[0], n[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var list = Console.ReadLine().Split().ToList();
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = list[k];
                }
            }
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                {
                    if (matrix[i,k] == matrix[i, k + 1] && matrix[i, k] == matrix[i+1, k] && matrix[i, k] == matrix[i+1, k+1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}