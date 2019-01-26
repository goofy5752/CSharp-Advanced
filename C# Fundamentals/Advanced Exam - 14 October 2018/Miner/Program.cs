using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n][];
            int rowOfS = 0;
            int colOfS = 0;
            int coals = 0;
            bool isDead = false;
            string[] commands = Console.ReadLine().Split();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine().Split();
                string chars = "";
                for (int k = 0; k < input.Length; k++)
                {
                    chars += input[k];
                }
                matrix[i] = chars.ToCharArray();
                if (matrix[i].Contains('s'))
                {
                    rowOfS = i;
                    colOfS = Array.IndexOf(matrix[i], 's');
                }
                for (int k = 0; k < matrix[i].Length; k++)
                {
                    if (matrix[i][k] == 'c')
                    {
                        coals++;
                    }
                }
            }
            
            for (int i = 0; i < commands.Length; i++)
            {
                MoveSam(matrix, ref rowOfS, ref colOfS, commands[i], ref coals, ref isDead);
                if (isDead)
                {
                    Console.WriteLine($"Game over! ({rowOfS}, {colOfS})");
                    break;
                }
                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({rowOfS}, {colOfS})");
                    break;
                }
                if (coals > 0 && i == commands.Length - 1)
                {
                    Console.WriteLine($"{coals} coals left. ({rowOfS}, {colOfS})");
                }
            }

        }
        private static void MoveSam(char[][] matrix, ref int row, ref int col, string command, ref int coals, ref bool isDead)
        {
            if (command == "right")
            {
                if (col != matrix[row].Length - 1)
                {
                    if (matrix[row][col + 1] == 'c')
                    {
                        matrix[row][col + 1] = '*';
                        coals--;
                        col++;
                    }
                    else if (matrix[row][col + 1] == 'e')
                    {
                        isDead = true;
                        col++;
                    }
                    else
                    {
                        col++;
                    }
                }
            }
            else if (command == "left")
            {
                if (col != 0)
                {
                    if (matrix[row][col - 1] == 'c')
                    {
                        matrix[row][col - 1] = '*';
                        coals--;
                        col--;
                    }
                    else if (matrix[row][col - 1] == 'e')
                    {
                        isDead = true;
                        col--;
                    }
                    else
                    {
                        col--;
                    }
                }
            }
            else if (command == "down")
            {
                if (row != matrix.GetLength(0) - 1)
                {
                    if (matrix[row + 1][col] == 'c')
                    {
                        matrix[row + 1][col] = '*';
                        coals--;
                        row++;
                    }
                    else if (matrix[row + 1][col] == 'e')
                    {
                        isDead = true;
                        row++;
                    }
                    else
                    {
                        row++;
                    }
                }
            }
            else
            {
                if (row != 0)
                {
                    if (matrix[row - 1][col] == 'c')
                    {
                        matrix[row - 1][col] = '*';
                        coals--;
                        row--;
                    }
                    else if (matrix[row - 1][col] == 'e')
                    {
                        isDead = true;
                        row--;
                    }
                    else
                    {
                        row--;
                    }
                }
            }
        }
    }
}