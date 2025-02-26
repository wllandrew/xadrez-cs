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

            if (Game.PossibleEnPassant != null 
                && Board.GetPiece(Position.Row, Position.Column - 1) == Game.PossibleEnPassant
                || Board.GetPiece(Position.Row, Position.Column + 1) == Game.PossibleEnPassant)
            {
                var i = (Color == Colors.Black) ? -1 : 1;
                res[Game.PossibleEnPassant!.Position.Row, Game.PossibleEnPassant!.Position.Column + i] = true;
            }

            return res;
        }
    }
}