using Board;

namespace Application
{
    public class Screen
    {
        public static void PrintBoard(ChessBoard board)
        {
            for (int i = 0; i < board.Row; i++)
            {
                Console.Write($"{i} ");

                for (int j = 0; j < board.Column; j++)
                {
                    if (board.Board[i, j] == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Board[i, j]);
                    }
                } 

                Console.WriteLine("");
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(Piece p)
        {
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
    }
}