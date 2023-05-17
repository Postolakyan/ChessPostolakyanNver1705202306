using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class King
    {
        public static char[,] Steps(int first_coordination, int second_coordination, char[,] board)
        {

            int sum_of_coordinations = first_coordination + second_coordination;
            int difference_of_coordinations = first_coordination - second_coordination;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 5 && j == 4)
                    {

                    }
                    if (i+1 == first_coordination || j+1 == second_coordination || i - 1 == first_coordination || j - 1 == second_coordination)
                    {
                        if (i + j == sum_of_coordinations && i != first_coordination && j != second_coordination
                      || i - j == difference_of_coordinations && i != first_coordination && j != second_coordination
                         )
                        {
                            Board.ReplaceFigure(board, i + 1, j + 1, '*');
                        }
                        if (j == second_coordination || i == first_coordination)
                        {
                            Board.ReplaceFigure(board, i + 1, j + 1, '*');

                        }

                    }

                }
            }
            Board.ReplaceFigure(board, first_coordination + 1, second_coordination + 1, 'K');
            Board.PrintBoard(board);
            return board;

        }
    }
}
