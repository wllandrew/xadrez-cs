using System;
using Board;

namespace Pieces
{
    public class King : Piece
    {
        public King(Colors color, ChessBoard board) : base(color, board) {}

        public override string ToString()
        {
            return "K";
        }

        public override bool[,] GetMovements()
        {
            // Inicializa valores como false
            var res = new bool[Board.Row, Board.Column];

            for (int i = Position.Row - 1; i <= Position.Row + 1; i++)
            {
                for (int j = Position.Column - 1; j <= Position.Column + 1; j++)
                {
                    if (CanMove(new Position(i, j)))
                    {
                        res[i, j] = true;
                    }
                }
            }

            return res;
        }
    }
}