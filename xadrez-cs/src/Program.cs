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
                // Escreve na tela o tabuleiro.
                Console.Clear();
                Screen.PrintGame(game);

                // Recebe input da posição inicial
                Console.Write("From: ");
                var input = Screen.ReadPosition().ToPosition();
               

                // Mostra as possibilidades de movimentos
                var possible = game.Board.GetPiece(input)!.GetMovements();
                Screen.PrintBoard(game.Board, possible);

                // Recebe input da posição final
                Console.Write("\nTo: ");
                var output = Screen.ReadPosition().ToPosition();
                game.Move(input, output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}