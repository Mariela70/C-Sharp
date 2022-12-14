using System;
using System.Linq;


namespace SyperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                int marieLives = int.Parse(Console.ReadLine());

                int n = int.Parse(Console.ReadLine());
                if (n == 0)
                {
                    return;
                }
                char[][] matrix = new char[n][];
                int marioRow = -1;
                int marioCol = -1;
                for (int row = 0; row < n; row++)
                {

                    matrix[row] = Console.ReadLine()?.ToCharArray();

                    for (int col = 0; col < matrix[row].Length; col++)
                    {

                        if (matrix[row][col] == 'M')
                        {
                            marioRow = row;
                            marioCol = col;
                        }
                    }

                    while (true)
                {
                    string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string command = tokens[0];
                    int enemyRow = int.Parse(tokens[1]);
                    int enemyCol = int.Parse((tokens[2]));

                    matrix[enemyRow][enemyCol] = 'B';
                    marieLives--;
                    matrix[marioRow][marioCol] = '-';
                    if (command == "W" && marioRow - 1 >= 0)//up
                    {
                        marioRow--;
                    }
                    else if (command == "S" && marioRow + 1 < n)//down
                    {
                        marioRow++;
                    }
                    else if (command == "A" && marioCol - 1 >= 0)//left
                    {
                        marioCol--;
                    }
                    else if (command == "D" && marioCol + 1 < matrix[0].Length)//right
                    {
                        marioCol++;
                    }
                    if (matrix[marioRow][marioCol] == 'B')
                    {
                        marieLives -= 2;
                    }
                    else if (matrix[marioRow][marioCol] == 'P')
                    {
                        matrix[marioRow][marioCol] = '-';
                        Console.WriteLine($"Mario has succesfully saved the princess! lives left: {marieLives}");
                        break;
                    }
                    if (marieLives <= 0)
                    {
                        matrix[marioRow - 1][marioCol] = 'X';
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}");
                        break;
                    }
                    matrix[marioRow][marioCol] = 'M';

                }
                for (int b = 0; b < matrix.Length; b++)
                {
                    Console.WriteLine(new string(matrix[b]));
                }
            }
        }
    }
}
