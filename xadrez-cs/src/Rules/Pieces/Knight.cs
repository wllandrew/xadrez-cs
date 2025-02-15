using System;
using Board;

namespace Pieces
{
    public class Knight : Piece
    {
        public Knight(Colors color, ChessBoard board) : base(color, board) {}

        public override string ToString()
        {
            return "N";
        }

    }
}