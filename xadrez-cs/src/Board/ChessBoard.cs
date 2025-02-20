namespace Board
{
    public class ChessBoard
    {
        public int Row;
        public int Column;
        public Piece?[,] Board;

        public ChessBoard(int row = 8, int column = 8)
        {
            this.Row = row;
            this.Column = column;
            this.Board = new Piece[Row, Column];
        }

        // Método GetPiece() utiliza sobrecarga 
        public Piece? GetPiece(int row, int column)
        {

            return this.Board[row, column];
        }

        public Piece? GetPiece(Position pos)
        {
            return this.Board[pos.Row, pos.Column];
        }

        public void SetPiece(Piece piece, Position pos)
        {
            if (!Exists(pos))
            {
                this.Board[pos.Row, pos.Column] = piece;
                piece.Position = pos;
            }
            else
            {
                throw new ChessBoardException("Piece already placed in this position");
            }
        }

        // Returns the removed piece
        public Piece? RemovePiece(Position p)
        {
            if (Exists(p))
            {
                var pp = this.GetPiece(p);
                this.Board[p.Row, p.Column] = null;
                return pp;
            }
            return null;
        }

        private void IsValid(Position pos)
        {
            if (pos.Row < 0
                || pos.Row > this.Row
                || pos.Column < 0
                || pos.Row > this.Column)
            {
                throw new ChessBoardException("Position is out of board range.");
            }
        }

        private bool Exists(Position pos)
        {
            this.IsValid(pos);
            return this.Board[pos.Row, pos.Column] != null;
        }
    }
}