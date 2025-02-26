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

        // Try de fora é usado pra debug, enquanto o de dentro para tratamento de erros na lógica.
        try
        {
            while (game.Active)
            {
                try
                {
                    // Escreve na tela o tabuleiro.
                    Console.Clear();
                    Screen.PrintGame(game);

                    // Recebe input da posição inicial
                    Console.Write("From: ");
                    var input = Screen.ReadPosition().ToPosition();
                    game.ValidateInitial(input);
                    
                    Console.Clear();

                    // Mostra as possibilidades de movimentos
                    var possible = game.Board.GetPiece(input)!.GetMovements();
                    Screen.PrintBoard(game.Board, possible);

                    // Recebe input da posição final
                    Console.Write("\nTo: ");
                    var output = Screen.ReadPosition().ToPosition();
                    game.ValidateFinal(input, output);
                    game.RealizeTurn(input, output);
                }
                catch (Exception e) when (
                    e is ChessBoardException 
                    || e is ChessGameException
                    || e is BoardInputException)
                {
                    Console.WriteLine("\n" + e.StackTrace);
                    Console.ReadLine();
                }

                Console.Clear();
                Screen.PrintBoard(game.Board);
                Console.WriteLine($"\nWinner is {game.Winner}");

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }
}