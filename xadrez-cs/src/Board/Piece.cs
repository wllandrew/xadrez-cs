namespace Board
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Colors Color { get; set; }
        public ChessBoard Board { get; set; }

        public Piece(Colors color, ChessBoard board)
        {
            this.Color = color;
            this.Board = board;
        }

        public bool CanMove(Position position)
        {
            if (!Board.IsValid(position))
            {
                return false;
            }

            var p = Board.GetPiece(position);
            if (p == null || p.Color != this.Color)
            {
                return true;
            }
            return false;
        }

        // Lógica deve ser abstrata pois é unica para cada peça
        public abstract bool[,] GetMovements();
    }
}