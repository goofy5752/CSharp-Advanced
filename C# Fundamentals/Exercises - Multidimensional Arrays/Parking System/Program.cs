using System;
using System.Linq;
using System.Collections.Generic;

namespace Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rows = nums[0];
            var cols = nums[1];

            int[,] matrix = new int[rows, cols];

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }

                var tokens = input.Split().Select(int.Parse).ToArray();

                var entryRow = tokens[0];
                var targetRow = tokens[1];
                var targetCol = tokens[2];

                //method that checks if the desired spot is free
                bool isFree = IsSpotFree(matrix, targetRow, targetCol);
                if (isFree)
                {
                    //fill the spot
                    matrix[targetRow, targetCol] = 1;

                    int movedRows = Math.Abs(entryRow - targetRow ) +1;
                    int totalMoves = movedRows + targetCol;
                    Console.WriteLine(totalMoves);
                    
                }
                else
                {
                    int movedRows = Math.Abs(entryRow - targetRow) + 1;

                    bool foundEmptySpot = false;

                    for (int i = 1; i < matrix.GetLength(1); i++)
                    {
                        if (matrix[targetRow,i] == 0)
                        {
                            matrix[targetRow, i] = 1;
                            Console.WriteLine(i+ movedRows);
                            foundEmptySpot = true;
                            break;
                        }
                    }

                    if (!foundEmptySpot)
                    {
                        Console.WriteLine($"Row {targetRow} full");
                    }
                }
            }
        }

        private static bool IsSpotFree(int[,] matrix, int targetRow, int targetCol)
        {
            if (targetRow>=0 && targetRow<= matrix.GetLength(0)-1 && targetCol>=0 && targetCol<= matrix.GetLength(1)-1)
            {
                if (matrix[targetRow, targetCol] == 0)
                {
                    return true;
                }
            }
           

            return false;
        }

       
    }
}