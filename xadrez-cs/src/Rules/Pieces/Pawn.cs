using System;
using Board;
using Rules;

namespace Pieces
{
    public class Pawn : Piece
    {
        public ChessMatch Game;
        public Pawn(Colors color, ChessBoard board, ChessMatch game) : base(color, board) 
        {
            this.Game = game;
        }

        public override string ToString()
        {
            return "P";
        }

        public override bool[,] GetMovements()
        {
            var res = new bool[Board.Row, Board.Column];

            var counter = (Position.Row == 1 || Position.Row == 6) ? 2 : 1;

            var change = (Color == Colors.Black) ? 1 : -1;

            for (int i = 1; i <= counter; i++)
            {
                var n = new Position(Position.Row  + (i * change), Position.Column);
                if (CanMove(n)
                    && Board.GetPiece(n) is null)
                {
                    res[Position.Row + (i * change), Position.Column] = true;
                }
            }

            CanTake(ref res, 1);
            CanTake(ref res, -1);

            EnPassantCheck(ref res, 1);
            EnPassantCheck(ref res, -1);

            return res;
        }

        // Checa de pode captura peças na diagonal
        private void CanTake(ref bool[,] res, int counter)
        {
            var change = (Color == Colors.Black) ? 1 : -1;
            var p = new Position(Position.Row + change, Position.Column + counter);

            if (Board.IsValid(p) && Board.GetPiece(p) is not null && Board.GetPiece(p)?.Color != Color)
            {
                res[p.Row, p.Column] = true;
            }
        }

        private void EnPassantCheck(ref bool[,] res, int change)
        {
            var ep1 = new Position(Position.Row, Position.Column + change);
            if (Board.IsValid(ep1))
            {
                var p = Board.GetPiece(ep1);
                if (p != null && p == Game.PossibleEnPassant && p.Color != Color)
                {
                    var columnChange = (Color == Colors.Black) ? 1 : -1;
                    res[ep1.Row + columnChange, ep1.Column] = true;
                }
            }
        }
    }
}