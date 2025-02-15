using System;
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
                        Console.Write($"{board.Board[i, j]} ");
                    }
                } 

                Console.WriteLine("");
            }
            Console.WriteLine("  a b c d e f g h");
        }
    }
}