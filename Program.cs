using System;
using System.Linq;

namespace OOP_Day2_Homework
{
   

    class Program
    {   
        public class CheckmateBoard
        {
            public void PrintCheckmatBoard()
            {
                string[] firstLastRow = new string[] { " ", "a", "b", "c", "d", "e", "f", "g", "h", " " };
                int[] firstLastColoumn = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

                const string darkCell = "@";
                const string lightCell = "#";

                string[] lightDarkRow = new string[] { darkCell, lightCell, darkCell, lightCell, darkCell, lightCell, darkCell, lightCell };
                string[] darkLightRow = new string[] { lightCell, darkCell, lightCell, darkCell, lightCell, darkCell, lightCell, darkCell };

                Console.WriteLine(string.Join(" ", firstLastRow));



                for (int i = 2; i <= 9; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(firstLastColoumn[i - 2] + " ");
                        Console.Write(string.Join(" ", lightDarkRow));
                        Console.Write(" " + firstLastColoumn[i - 2]);
                    }

                    else
                    {
                        Console.Write(firstLastColoumn[i - 2] + " ");
                        Console.Write(string.Join(" ", darkLightRow));
                        Console.Write(" " + firstLastColoumn[i - 2]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine(string.Join(" ", firstLastRow));
            }
        }

        static void Main(string[] args)
    {
        CheckmateBoard objBoard = new CheckmateBoard();
        objBoard.PrintCheckmatBoard();
    }
}

}
