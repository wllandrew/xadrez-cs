using System;
using Board;

namespace Pieces
{
    public class Queen : Piece
    {
        public Queen(Colors color, ChessBoard board) : base(color, board) {}
    
        public override string ToString()
        {
            return "Q";
        }
    }
}