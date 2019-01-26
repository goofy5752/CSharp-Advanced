using System;
using System.Linq;

namespace Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[input[0],input[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = "" + alphabet[i] + alphabet[i] + alphabet[i];
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = "" + alphabet[i] + alphabet[k + i] + alphabet[i];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write(matrix[i, k] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}