namespace Board
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Colors Color { get; private set; }
        public ChessBoard Board { get; private set; }

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

        public bool IsThereMovements()
        {
            bool[,] movements = GetMovements();
            
            for (int i = 0; i < Board.Row; i++)
            {
                for (int j = 0; j < Board.Column; j++)
                {
                    if (movements[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CouldMoveTo(Position pos)
        {
            return GetMovements()[pos.Row, pos.Column];
        }

        // Lógica deve ser abstrata pois é unica para cada peça
        public abstract bool[,] GetMovements();
    }
}