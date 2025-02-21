using System;
using Board;

namespace Pieces
{
    public class Rook(Colors color, ChessBoard board) : Piece(color, board)
    {
        public override string ToString()
        {
            return "R";
        }

        public override bool[,] GetMovements()
        {
            var res = new bool[Board.Row, Board.Column];

            TraverseLine(ref res, 1, 'c');
            TraverseLine(ref res, -1, 'c');
            TraverseLine(ref res, 1, 'r');
            TraverseLine(ref res, -1, 'r');

            return res;
        }

        // Para evitar repetições desnecessárias de código
        private void TraverseLine(ref bool[,] res, int change, char line)
        {
            Position p;
            if (line == 'c')
            {
                p = new Position(Position.Row, Position.Column + change);
            }
            else
            {
                p = new Position(Position.Row + change, Position.Column);
            }
            while (CanMove(p))
            {
                res[p.Row, p.Column] = true;

                if (Board.GetPiece(p) != null)
                {
                    break;
                }

                if (line == 'c')
                {
                    p.Column += change;
                }
                else 
                {
                    p.Row += change;
                }
            }
        }
    }
}