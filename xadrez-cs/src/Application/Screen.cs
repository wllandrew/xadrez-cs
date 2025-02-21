using System.Drawing;
using Board;
using Rules;

namespace Application
{
    public class Screen
    {

        public static void PrintGame(ChessMatch game)
        {
            Screen.PrintBoard(game.Board);
            Screen.PrintTurn(game.Turn);
            Screen.PrintList(game.WhitePieces, Colors.White);
            Screen.PrintList(game.BlackPieces, Colors.Black);
            System.Console.WriteLine("");
        }
        public static void PrintBoard(ChessBoard board)
        {
            for (int i = 0; i < board.Row; i++)
            {
                Console.Write($"{board.Row - i}   ");

                for (int j = 0; j < board.Column; j++)
                {
                    PrintPiece(board.GetPiece(i, j));
                } 

                Console.WriteLine("");
            }
            Console.WriteLine("\n    a b c d e f g h\n");
        }

        public static void PrintBoard(ChessBoard board, bool[,] possible)
        {
            for (int i = 0; i < board.Row; i++)
            {
                Console.Write($"{board.Row - i}   ");

                for (int j = 0; j < board.Column; j++)
                {
                    if (possible[i, j] == true)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    } 
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    PrintPiece(board.Board[i, j]);
                } 
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n    a b c d e f g h\n");
        }

        public static void PrintPiece(Piece? p)
        {
            if (p == null)
            {
                Console.Write("- ");
                return;
            }

            if (p.Color == Colors.Black)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(p + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(p + " ");
            }
        }

        public static void PrintList(List<Piece> list, Colors color)
        {
            if (color == Colors.White)
            {
                Console.Write("Black captured: [ ");                
            }
            else
            {
                Console.Write("White captured: [ ");        
            }
            foreach (Piece piece in list)
            {
                Screen.PrintPiece(piece);
            }
            System.Console.WriteLine("]");
        }

        public static void PrintTurn(int turn)
        {
            string c = (turn % 2 == 1) ? "White" : "Black";

            Console.WriteLine($"Turn: {turn}");
            Console.WriteLine($"{c} moves.\n");
        }

        public static BoardPosition ReadPosition()
        {
            string? s = Console.ReadLine();
            if (s == null || s.Length != 2)
            {
                throw new BoardInputException("Invalid Input");
            }
            return new BoardPosition(s[0], int.Parse(s[1] + ""));
        }
    }
}