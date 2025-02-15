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
                } 

                Console.WriteLine("");
            }
            Console.WriteLine("  A B C D E F G H");
        }
    }
}