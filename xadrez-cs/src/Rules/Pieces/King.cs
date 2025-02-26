using System;
using Board;
using Rules;

namespace Pieces
{
    public class King : Piece
    {
        public bool HasMoved { get; set; } = false;
        public ChessMatch Match;
        public King(Colors color, ChessBoard board, ChessMatch match) : base(color, board) 
        {
            this.Match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        public override bool[,] GetMovements()
        {
            // Inicializa valores como false
            var res = new bool[Board.Row, Board.Column];

            for (int i = Position.Row - 1; i <= Position.Row + 1; i++)
            {
                for (int j = Position.Column - 1; j <= Position.Column + 1; j++)
                {
                    if (CanMove(new Position(i, j)))
                    {
                        res[i, j] = true;
                    }
                }
            }

            if (!HasMoved && !Match.Check)
            {
                if (CheckForBigCastle())
                {   
                    res[Position.Row, Position.Column + 2] = true;
                }
                if (CheckForSmallCastle())
                {
                    res[Position.Row, Position.Column - 2] = true;                
                }   
            }

            return res;
        }

        private bool CheckForSmallCastle()
        {
            for (int i = Position.Column + 1; i < Board.Column; i++)
            {
                Piece? n = Board.GetPiece(new Position(Position.Row, i));

                if (i < Board.Column - 1 && n != null)
                {
                    return false;
                }
                else if (i == Board.Column - 1 && (n is not Rook || n?.Color != this.Color))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckForBigCastle()
        {
            for (int i = Position.Column - 1; i >= 0; i--)
            {
                Piece? n = Board.GetPiece(new Position(Position.Row, i));

                if (i > 1  && n != null)
                {
                    return false;
                }
                else if (i == 0 && (n is not Rook || n.Color != this.Color))
                {
                    return false;
                }
            }
            return true;   
        }
    }   
}