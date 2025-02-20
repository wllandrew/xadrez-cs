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

        // Lógica deve ser abstrata pois é unica para cada peça
        public abstract bool CanMove(Position position);

        public abstract bool[,] GetMovements();
    }
}