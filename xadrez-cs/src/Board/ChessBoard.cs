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
            if (IsValid(new Position(row, column)))
            {
                return this.Board[row, column];
            }
            throw new ChessBoardException("Invalid Position.");
        }

        public Piece? GetPiece(Position pos)
        {
            if (IsValid(pos))
            {
                return this.Board[pos.Row, pos.Column];
            }
            throw new ChessBoardException("Invalid Position.");
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

        public bool IsValid(Position pos)
        {
            if (pos.Row < 0
                || pos.Row >= this.Row
                || pos.Column < 0
                || pos.Column >= this.Column)
            {
                return false;
            }
            return true;
        }

        private bool Exists(Position pos)
        {
            if (this.IsValid(pos))
            {
                return this.Board[pos.Row, pos.Column] != null;            
            }
            return false;
        }
    }
}