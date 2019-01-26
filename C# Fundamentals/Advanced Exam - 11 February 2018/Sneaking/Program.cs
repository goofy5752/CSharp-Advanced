using System;
using System.Linq;

namespace Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n][];

            int row = 0;
            int col = 0;
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
                if (matrix[i].Contains('S'))
                {
                    row = i;
                    col = Array.IndexOf(matrix[i], 'S');
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                MoveEnemies(matrix);

                if (matrix[row].Contains('b') && Array.IndexOf(matrix[row], 'b') < col)
                {
                    Console.WriteLine($"Sam died at {row}, {col}");
                    matrix[row][col] = 'X';
                    break;
                }
                if (matrix[row].Contains('d') && Array.IndexOf(matrix[row], 'd') > col)
                {
                    Console.WriteLine($"Sam died at {row}, {col}");
                    matrix[row][col] = 'X';
                    break;
                }

                MoveSam(matrix, ref row, ref col, commands[i]);

                if (matrix[row].Contains('N'))
                {
                    int indexOfNikoladze = Array.IndexOf(matrix[row], 'N');
                    matrix[row][indexOfNikoladze] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }
            foreach (var r in matrix)
            {
                Console.WriteLine(string.Join("", r));
            }
        }

        private static void MoveSam(char[][] matrix, ref int row, ref int col, char command)
        {
            matrix[row][col] = '.';
            switch (command)
            {
                case 'U': row--; break;
                case 'D': row++; break;
                case 'R': col++; break;
                case 'L': col--; break;
                default:
                    break;
            }
            matrix[row][col] = 'S';
        }

        private static void MoveEnemies(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i].Contains('d'))
                {
                    int colD = Array.IndexOf(matrix[i], 'd');
                    if (colD == 0)
                    {
                        matrix[i][0] = 'b';
                    }
                    else
                    {
                        matrix[i][colD] = '.';
                        colD--;
                        matrix[i][colD] = 'd';
                    }
                }
                else if (matrix[i].Contains('b'))
                {
                    int colB = Array.IndexOf(matrix[i], 'b');
                    if (colB == matrix[i].Length - 1)
                    {
                        matrix[i][0] = 'd';
                    }
                    else
                    {
                        matrix[i][colB] = '.';
                        colB++;
                        matrix[i][colB] = 'b';
                    }
                }
            }
        }
    }
}