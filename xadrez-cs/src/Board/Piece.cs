using System;

namespace Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Colors Color { get; set; }
        public ChessBoard Board { get; set; }

        public Piece(Colors color, ChessBoard board)
        {
            this.Color = color;
            this.Board = board;
            this.Position = null;
        }

    }
}