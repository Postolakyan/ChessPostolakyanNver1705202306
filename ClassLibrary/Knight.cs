using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Knight
    {
        public static char[,] Steps(int first_coordination, int second_coordination, char[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i + 2 == first_coordination || i - 2 == first_coordination)
                    {
                        if (j + 1 == second_coordination || j - 1 == second_coordination)
                        {
                            Board.ReplaceFigure(board, i + 1, j + 1, '*');
                        }
                    } else if (i +1 == first_coordination || i-1 == first_coordination )
                    {
                        if (j+2 == second_coordination || j-2 == second_coordination)
                        {
                            Board.ReplaceFigure(board, i + 1, j + 1, '*');
                        }
                    }
                }
            }
            Board.ReplaceFigure(board, first_coordination + 1, second_coordination + 1, 'B');
            Board.PrintBoard(board);
            return board;
        }
        public static bool MoveTo(int initial_first_coordination, int initial_second_coordination, int dest_first_coordination, int dest_second_coordination)
        {
            var board = Steps(initial_first_coordination, initial_second_coordination, Board.CreateBoard());
            if (board[dest_second_coordination, dest_first_coordination] == '*')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
