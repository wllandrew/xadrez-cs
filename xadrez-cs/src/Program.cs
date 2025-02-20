using System;
using Application;
using Board;
using Rules;

namespace Principal;

class Program
{
    static void Main(string[] args)
    {
        var game = new ChessMatch();

        try
        {
            while (game.Active)
            {
                Screen.PrintGame(game);
                Console.Write("From: ");
                var input = Screen.ReadPosition().ToPosition();
                Console.Write("\nTo: ");
                var output = Screen.ReadPosition().ToPosition();
                game.Move(input, output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}