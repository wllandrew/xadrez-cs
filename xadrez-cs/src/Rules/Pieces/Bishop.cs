using System;
using Board;

namespace Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Colors color, ChessBoard board) : base(color, board) {}

        public override string ToString()
        {
            return "B";
        }
    }
}