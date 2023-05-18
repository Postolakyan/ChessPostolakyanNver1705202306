using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Board
    {
        public static char[,] CreateBoard()
        {
            char[,] board = new char[8, 8];

            // Assign '#' or '@' to each cell to represent the chessboard pattern
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0 && j % 2 == 1 || j % 2 == 0 && i % 2 == 1)
                    {
                        board[i, j] = '#';
                    }
                    else
                    {
                        board[i, j] = '@';
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            PrintBoard(board); // Print the chessboard to the console
            return board;
        }
        public static void PrintBoard(char[,] matrix)
        {
            Console.CursorTop = 2;

            for (int i = 0; i < 8; i++)
            {
                Console.CursorLeft = 3;
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j] == '#')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {matrix[i, j]} ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    else if (matrix[i, j] == '@')
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {matrix[i, j]} ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else if (matrix[i, j] == '*')
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write($" {matrix[i, j]} ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else if (matrix[i, j] == '^')
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write($" {matrix[i, j]} ");
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {matrix[i, j]} ");
                        Console.BackgroundColor = ConsoleColor.Black;


                    }
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static char[,] ReplaceFigure(char[,] board, int firstindex, int secondindex, char figure)
        {
            board[secondindex - 1, firstindex - 1] = figure;
            return board;
        }



    }
}
