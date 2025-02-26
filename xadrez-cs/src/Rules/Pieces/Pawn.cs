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
                if (CanMove(new Position(Position.Row  + (i * change), Position.Column)))
                {
                    res[Position.Row + (i * change), Position.Column] = true;
                }
            }

            EnPassantCheck(ref res, 1);
            EnPassantCheck(ref res, -1);

            return res;
        }

        private void EnPassantCheck(ref bool[,] res, int change)
        {
            var ep1 = new Position(Position.Row, Position.Column + change);
            if (Board.IsValid(ep1))
            {
                var p = Board.GetPiece(ep1);
                if (p != null && p == Game.PossibleEnPassant)
                {
                    var columnChange = (Color == Colors.Black) ? 1 : -1;
                    res[ep1.Row + columnChange, ep1.Column] = true;
                }
            }
        }
    }
}