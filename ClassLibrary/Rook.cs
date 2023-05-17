using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Rook
    {
        public static char[,] Steps(int x, int y, char[,] board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == y || i== x)
                    {
                        Board.ReplaceFigure(board,i+1,j+1,'^');
                    }
                }
            }
            Board.ReplaceFigure(board, x + 1, y + 1, 'R');
            Board.PrintBoard(board);
            return board;
        }
    }
}
