using System;
using Board;

namespace Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Colors color, ChessBoard board) : base(color, board) {}

        public override string ToString()
        {
            return "P";
        }

        public override bool[,] GetMovements()
        {
            var res = new bool[Board.Row, Board.Column];

            var counter = (Position.Row == 1 || Position.Row == 6) ? 2 : 1;

            var change = (Color == Colors.Black) ? -1 : 1;

            for (int i = 1; i <= counter; i++)
            {
                if (CanMove(new Position(Position.Row  + (i * change), Position.Column)))
                {
                    res[Position.Row + (i * change), Position.Column] = true;
                }
            }

            return res;
        }
    }
}