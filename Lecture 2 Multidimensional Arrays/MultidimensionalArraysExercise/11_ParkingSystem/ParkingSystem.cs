using System;
using System.Linq;

namespace _11_ParkingSystem
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            // false = free, true = busy
            bool[][] matrix = new bool[rows][];

            string input = Console.ReadLine();
            while (input != "stop")
            {
                int[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int enterRow = command[0];
                int destinationRow = command[1];
                int destinationCol = command[2];
                int distance = 0;

                distance += Math.Abs(enterRow - destinationRow);
                if (matrix[destinationRow]?.Length == null)
                {
                    matrix[destinationRow] = new bool[cols];
                }
                // is desired cell free?
                if (matrix[destinationRow][destinationCol] == false)
                {
                    matrix[destinationRow][destinationCol] = true;
                    distance += destinationCol + 1;
                    Console.WriteLine(distance);
                }
                else
                {   //desired cell busy, find nearest free
                    int offset = 1;

                    int nearestFreeCell = -1;
                    while (destinationCol - offset > 0 || destinationCol + offset < cols)
                    {
                        if (destinationCol - offset > 0 && matrix[destinationRow][ destinationCol - offset] == false)
                        {
                            nearestFreeCell = destinationCol - offset;
                            distance += nearestFreeCell + 1;
                            matrix[destinationRow][ destinationCol - offset] = true;
                            break;
                        }
                        if (destinationCol + offset < cols && matrix[destinationRow][ destinationCol + offset] == false)
                        {
                            nearestFreeCell = destinationCol + offset;
                            distance += nearestFreeCell + 1;
                            matrix[destinationRow][ destinationCol + offset] = true;
                            break;
                        }
                        offset++;
                    }

                    if (nearestFreeCell == -1)
                    {
                        Console.WriteLine($"Row {destinationRow} full");
                    }
                    else
                    {
                        Console.WriteLine(distance);
                    }

                }
                input = Console.ReadLine();
            }

        }
    }
}
