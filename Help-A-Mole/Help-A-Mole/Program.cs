using System;
using System.Linq;

namespace Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] coordinates = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[n, n];
            int snakeRow = 0;
            int snakeCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'M')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }

            }
            for (int i = 0; i < coordinates.Length - 1; i += 2)
            {
                int row = coordinates[i];
                int col = coordinates[i + 1];
                if (!IsInRange(matrix, row, col))
                {
                    continue;

                }
                if (matrix[row, col] == ">")
                {
                    secondPlayer--;
                    matrix[row, col] = "X";
                    destroyedShip++;
                }
                else if (matrix[row, col] == "<")
                {
                    firstPlayer--;
                    matrix[row, col] = "X";
                    destroyedShip++;

                }
                else if (matrix[row, col] == "#")
                {
                    if (IsInRange(matrix, row - 1, col))
                    {
                        if (matrix[row - 1, col] == ">")
                        {
                            secondPlayer--;
                            matrix[row - 1, col] = "X";
                            destroyedShip++;
                        }
                        else if (matrix[row - 1, col] == "<")
                        {
                            firstPlayer--;
                            matrix[row - 1, col] = "X";
                            destroyedShip++;
                        }
                    }
                    //down
                    if (IsInRange(matrix, row + 1, col))
                    {
                        if (matrix[row + 1, col] == ">")
                        {
                            secondPlayer--;
                            matrix[row + 1, col] = "X";
                            destroyedShip++;
                        }
                        else if (matrix[row + 1, col] == "<")
                        {
                            firstPlayer--;
                            matrix[row + 1, col] = "X";
                            destroyedShip++;
                        }
                    }
                    //right
                    if (IsInRange(matrix, row, col + 1))
                    {
                        if (matrix[row, col + 1] == ">")
                        {
                            secondPlayer--;
                            matrix[row, col + 1] = "X";
                            destroyedShip++;
                        }
                        else if (matrix[row, col + 1] == "<")
                        {
                            firstPlayer--;
                            matrix[row, col + 1] = "X";
                            destroyedShip++;
                        }
                    }
                    //left
                    if (IsInRange(matrix, row, col - 1))
                    {
                        if (matrix[row, col - 1] == ">")
                        {
                            secondPlayer--;
                            matrix[row, col - 1] = "X";
                            destroyedShip++;
                        }
                        else if (matrix[row, col - 1] == "<")
                        {
                            firstPlayer--;
                            matrix[row, col - 1] = "X";
                            destroyedShip++;
                        }
                    }
                    //up left
                    if (IsInRange(matrix, row - 1, col - 1))
                    {
                        if (matrix[row - 1, col - 1] == ">")
                        {
                            secondPlayer--;
                            matrix[row - 1, col - 1] = "X";
                            destroyedShip++;
                        }
                        else if (matrix[row - 1, col - 1] == "<")
                        {
                            firstPlayer--;
                            matrix[row - 1, col - 1] = "X";
                            destroyedShip++;
                        }
                    }
                    //up right
                    if (IsInRange(matrix, row - 1, col + 1))
                    {
                        if (matrix[row - 1, col + 1] == ">")
                        {
                            secondPlayer--;
                            matrix[row - 1, col + 1] = "X";
                            destroyedShip++;
                        }
                        else if (matrix[row - 1, col + 1] == "<")
                        {
                            firstPlayer--;
                            matrix[row - 1, col + 1] = "X";
                            destroyedShip++;
                        }
                    }
                    //down left
                    if (IsInRange(matrix, row + 1, col - 1))
                    {
                        if (matrix[row + 1, col - 1] == ">")
                        {
                            secondPlayer--;
                            matrix[row + 1, col - 1] = "X";
                            destroyedShip++;
                        }
                        else if (matrix[row + 1, col - 1] == "<")
                        {
                            firstPlayer--;
                            matrix[row + 1, col - 1] = "X";
                            destroyedShip++;
                        }
                    }
                    //down right
                    if (IsInRange(matrix, row + 1, col + 1))
                    {
                        if (matrix[row + 1, col + 1] == ">")
                        {
                            secondPlayer--;
                            matrix[row + 1, col + 1] = "X";
                            destroyedShip++;
                        }
                        else if (matrix[row + 1, col + 1] == "<")
                        {
                            firstPlayer--;
                            matrix[row + 1, col + 1] = "X";
                            destroyedShip++;
                        }
                    }

                }
                if (firstPlayer == 0 || secondPlayer == 0)
                {
                    break;
                }


            }
            if (firstPlayer > 0 && secondPlayer > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayer} ships left. Player Two has {secondPlayer} ships left.");
            }
            else if (firstPlayer > 0)
            {
                Console.WriteLine($"Player One has won the game! { destroyedShip} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"Player Two has won the game! { destroyedShip} ships have been sunk in the battle.");
            }
        }
        private static bool IsInRange(string[,] matrix, int row, int col)
        => row >= 0 && row <= matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    }
}
        
    

