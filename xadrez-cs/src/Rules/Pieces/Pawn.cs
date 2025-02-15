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
    }
}