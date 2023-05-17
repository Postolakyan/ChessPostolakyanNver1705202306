using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Pawn
    {
        public static char[,] Steps(int first_coordination, int second_coordination, char[,] board)
        {
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        if (i == 4 && j == 0)
            //        {

            //        }
            //        if (j + 1 == first_coordination)
            //        {
            //            if (i + 1 == second_coordination || i == second_coordination || i - 1 == second_coordination)
            //            {
            //                Board.ReplaceFigure(board, j + 1, i + 1, '*');

            //            }
            //        }
            //    }
            //}
            Board.ReplaceFigure(board, first_coordination + 1, second_coordination + 1, 'P');
            Board.PrintBoard(board);
            return board;
        }


    }
}
