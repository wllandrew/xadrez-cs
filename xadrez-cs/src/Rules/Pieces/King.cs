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
    }
}