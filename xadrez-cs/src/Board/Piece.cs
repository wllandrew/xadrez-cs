using System;

namespace Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Colors Color { get; set; }
        public ChessBoard Board { get; set; }

        public Piece(Position position, Colors color, ChessBoard board)
        {
            this.Position = position;
            this.Color = color;
            this.Board = board;
        }

    }
}