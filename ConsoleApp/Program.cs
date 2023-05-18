using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunTheProgramm();
        }

        public static void RunTheProgramm()
        {
            bool exit = false;
            while (!exit)
            {
                Draw(); // Draw the chessboard and get user input
                Console.CursorTop = 20;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Do you want to try Again? (Y/N)");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();
                if (input.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    exit = true;
                    Console.Clear();
                }
                Console.Clear();
            }
        }
        public static void Draw()
        {
            Console.CursorLeft = 3;
            string data = "ABCDEFGH";
            List<char> latterslist = new List<char>();
            latterslist.AddRange(data);
            string numbers = "01234567";
            List<char> numberslist = new List<char>();
            numberslist.AddRange(numbers);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            // Draw letters at the top of the board
            foreach (char c in latterslist)
            {
                Console.Write($" {c} ");
            }
            Console.WriteLine("");
            Console.CursorTop = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("------------------------------");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            int[] nums = new int[9];
            for (int i = 1; i <= 8; i++)
            {
                nums[i] = i;
                Console.WriteLine(nums[i]);
            }
            DrawEdges(2, 2);
            DrawEdges(2, 28);
            Console.CursorTop = 10;
            Console.Write("------------------------------");
            Board.CreateBoard(); // Initialize the chessboard and print it
            var input = InputCoordinations(latterslist, numberslist, out int firstindex, out int secondindex);
            Coordinations coordinations = new Coordinations();
            coordinations.initial_first_coordination = firstindex;
            coordinations.intiial_second_coordination = secondindex;
            char.ToUpper(input);
            switch (input)
            {
                case 'K':
                    King.Steps(coordinations.initial_first_coordination - 1, coordinations.intiial_second_coordination - 1, Board.CreateBoard());
                    break;
                case 'Q':
                    Queen.Steps(coordinations.initial_first_coordination - 1, coordinations.intiial_second_coordination - 1, Board.CreateBoard());
                    break;
                case 'R':
                    Rook.Steps(coordinations.initial_first_coordination - 1, coordinations.intiial_second_coordination - 1, Board.CreateBoard());
                    break;
                case 'B':
                    Bishop.Steps(coordinations.initial_first_coordination - 1, coordinations.intiial_second_coordination - 1, Board.CreateBoard());
                    break;
                case 'N':
                    Knight.Steps(coordinations.initial_first_coordination - 1, coordinations.intiial_second_coordination - 1, Board.CreateBoard());
                    break;
                case 'P':
                    Pawn.Steps(coordinations.initial_first_coordination - 1, coordinations.intiial_second_coordination - 1, Board.CreateBoard());
                    break;
            }

            Console.CursorTop = 20;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do you want to Move the figure Y/N ? ");
            Console.ForegroundColor = ConsoleColor.White;
            string res = Console.ReadLine();
            if (res.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
            }
            else
            {
                MoveFigure(latterslist, numberslist, input, firstindex, secondindex);
            }
        }

        public static void DrawEdges(int top, int left)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorTop = top;
            for (int i = 0; i < 8; i++)
            {
                Console.CursorLeft = left;
                Console.WriteLine("|");
            }
        }


        public static void MoveFigure(List<char> letters, List<char> numbers, char figure, int firstindex, int secondindex)
        {



            bool exit = false;

            while (!exit)
            {
                Console.CursorTop = 21;
                int initial_first_index = 0;
                int initial_second_index = 0;
                char initial_first = '0';
                char initial_second = '0';

                Console.WriteLine("Please Insert The Initial Coordinations");
                string initial = Console.ReadLine();

                // Check if the user wants to exit
                if (initial.ToLower() == "exit")
                {
                    exit = true;
                    break;
                }
            initial_first = initial[0];
            initial_second = initial[1];
            Console.WriteLine("Please Insert The Destination Coordinations");
            string destination = Console.ReadLine();

            char dest_first = destination[0];
            char dest_second = destination[1];
            int dest_first_index = 0;
            int dest_second_index = 0;
            bool valid = CheckIfValid(letters, numbers, ref initial_first, ref initial_second);
            bool isvalid = CheckIfValid(letters, numbers, ref dest_first, ref dest_second);

            for (int i = 0; i < letters.Count; i++)
            {
                if (initial_first == letters[i])
                {
                    initial_first_index = i + 1;
                }
                if (dest_first == letters[i])
                {
                    dest_first_index = i + 1;
                }
            }
            for (int j = 1; j < numbers.Count; j++)
            {
                if (initial_second == numbers[j])
                {
                    initial_second_index = j + 1;
                }
                if (dest_second == numbers[j])
                {
                    dest_second_index = j + 1;
                }
            }
                if (valid && isvalid)
                {
                    switch (figure)
                    {
                        case 'K':
                            bool validStep_K = King.MoveTo(initial_first_index - 1, initial_second_index - 1, dest_first_index - 1, dest_second_index - 1);
                            if (validStep_K)
                            {
                                King.Steps(dest_first_index - 1, dest_second_index - 1, Board.CreateBoard());
                            }
                            else
                            {
                                Console.CursorTop += 15;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The Destination Coodrinations is not Valid Please Insert Valid Coordinations ");
                                Console.ReadLine();
                                MoveFigure(letters, numbers, figure, firstindex, secondindex);
                            }
                            break;
                        case 'Q':
                            bool validStep_Q = Queen.MoveTo(initial_first_index - 1, initial_second_index - 1, dest_first_index - 1, dest_second_index - 1);
                            if (validStep_Q)
                            {
                                Queen.Steps(dest_first_index - 1, dest_second_index - 1, Board.CreateBoard());
                            }
                            else
                            {
                                Console.CursorTop += 15;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The Destination Coodrinations is not Valid Please Insert Valid Coordinations ");
                                Console.ReadLine();
                                MoveFigure(letters, numbers, figure, firstindex, secondindex);
                            }
                            break;
                        case 'R':
                            bool validStep_R = Rook.MoveTo(initial_first_index - 1, initial_second_index - 1, dest_first_index - 1, dest_second_index - 1);
                            if (validStep_R)
                            {
                                Rook.Steps(dest_first_index - 1, dest_second_index - 1, Board.CreateBoard());
                            }
                            else
                            {
                                Console.CursorTop += 15;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The Destination Coodrinations is not Valid Please Insert Valid Coordinations ");
                                Console.ReadLine();
                                MoveFigure(letters, numbers, figure, firstindex, secondindex);
                            }
                            break;
                        case 'B':
                            bool validStep_B = Bishop.MoveTo(initial_first_index - 1, initial_second_index - 1, dest_first_index - 1, dest_second_index - 1);
                            if (validStep_B)
                            {
                                Bishop.Steps(dest_first_index - 1, dest_second_index - 1, Board.CreateBoard());
                            }
                            else
                            {
                                Console.CursorTop += 15;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The Destination Coodrinations is not Valid Please Insert Valid Coordinations ");
                                Console.ReadLine();
                                MoveFigure(letters, numbers, figure, firstindex, secondindex);
                            }
                            break;
                        case 'N':
                            bool validStep_N = Knight.MoveTo(initial_first_index - 1, initial_second_index - 1, dest_first_index - 1, dest_second_index - 1);
                            if (validStep_N)
                            {
                                Knight.Steps(dest_first_index - 1, dest_second_index - 1, Board.CreateBoard());
                            }
                            else
                            {
                                Console.CursorTop += 15;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The Destination Coodrinations is not Valid Please Insert Valid Coordinations ");
                                Console.ReadLine();
                                MoveFigure(letters, numbers, figure, firstindex, secondindex);
                            }
                            break;
                        case 'P':
                            bool validStep_P = Pawn.MoveTo(initial_first_index - 1, initial_second_index - 1, dest_first_index - 1, dest_second_index - 1);
                            if (validStep_P)
                            {
                                Pawn.Steps(dest_first_index - 1, dest_second_index - 1, Board.CreateBoard());
                            }
                            else
                            {
                                Console.CursorTop += 15;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The Destination Coodrinations is not Valid Please Insert Valid Coordinations ");
                                Console.ReadLine();
                                MoveFigure(letters, numbers, figure, firstindex, secondindex);
                            }
                            break;
                    }
                }
            }
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
        public static char InputCoordinations(List<char> letters, List<char> numbers, out int firstindex, out int secondindex)
        {

            Console.WriteLine("");
            Console.WriteLine("Please Choose The Figure");
            firstindex = 0;
            secondindex = 0;
            Dictionary<char, string> figures = new Dictionary<char, string>
            {
                {'K',"King" },
                {'Q',"Queen" },
                {'N',"KNights" },
                {'R',"Rook" },
                {'B',"Bishop" },
                {'P',"Pawn" }
            };
            foreach (var item in Enum.GetValues(typeof(Figures)))
            {
                // Console.WriteLine(item);
            }
            foreach (KeyValuePair<char, string> c in figures)
            {
                Console.WriteLine($" {c.Key} -> {c.Value}");
            }
            Char.TryParse(Console.ReadLine(), out char figure);
            bool valid = CheckIfValid(figures, ref figure);
            if (valid)
            {
                Console.WriteLine("Please Insert Coordinations");
                string coordinat = Console.ReadLine();
                if (coordinat.Length != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Insert Valid Values");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Do you want to try Again? (Y/N)");
                    Console.ForegroundColor = ConsoleColor.White;
                    string input = Console.ReadLine();
                    if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        RunTheProgramm();
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                char firstelement = coordinat[0];
                char secondelement = coordinat[1];
                bool isvalid = CheckIfValid(letters, numbers, ref firstelement, ref secondelement);
                if (isvalid)
                {
                    for (int i = 0; i < letters.Count; i++)
                    {
                        if (firstelement == letters[i])
                        {
                            firstindex = i + 1;
                            break;
                        }
                    }
                    for (int j = 0; j < numbers.Count; j++)
                    {
                        if (secondelement == numbers[j])
                        {
                            secondindex = j + 1;
                            break;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Insert Valid Values");
                    Console.WriteLine("Do you want to try Again (Y/N)");
                    Console.ForegroundColor = ConsoleColor.White;
                    string input = Console.ReadLine();
                    if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        RunTheProgramm();
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            return figure;

        }
        private static bool CheckIfValid(List<char> letters, List<char> numbers, ref char firstelement, ref char secondelement)
        {
            firstelement = char.ToUpper(firstelement);
            secondelement = char.ToUpper(secondelement);
            int second_element = secondelement - '0';
            second_element--;
            char.TryParse(second_element.ToString(), out secondelement);
            bool firstisvalid = false;
            bool secondisvalid = false;
            foreach (var item in letters)
            {

                if (firstelement == item)
                {
                    firstisvalid = true;
                }
            }
            if (!firstisvalid)
            {
                Console.WriteLine("The First Coordinate is not Valid Please insert Valid coordination");
            }
            foreach (var item in numbers)
            {
                if (secondelement == item)
                {
                    secondisvalid = true;
                }
            }
            if (!secondisvalid)
            {
                Console.WriteLine("The Second Coordinate is not Valid Please insert Valid coordination. ");
            }
            if (firstisvalid && secondisvalid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckIfValid(Dictionary<char, string> figures, ref char figure)
        {
            bool isvalid = false;
            figure = char.ToUpper(figure);
            if (figures.ContainsKey(figure))
            {
                isvalid = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Input is not Valid ");
                Console.WriteLine("Do you want to try Again? (Y/N)");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();
                if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    RunTheProgramm();
                }
            }
            return isvalid;
        }

    }
}
