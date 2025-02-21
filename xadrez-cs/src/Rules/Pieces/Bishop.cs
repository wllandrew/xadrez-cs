using System;
using Board;

namespace Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Colors color, ChessBoard board) : base(color, board) {}

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] GetMovements()
        {
            var res = new bool[Board.Row, Board.Column];

            TraverseCross(ref res, -1, 1);
            TraverseCross(ref res, -1, -1);
            TraverseCross(ref res, 1, 1);
            TraverseCross(ref res, 1, -1);
            
            return res;
        }

        private void TraverseCross(ref bool[,] res, int horizontal, int vertical)
        {
            var p = new Position(Position.Row + vertical, Position.Column + horizontal);
            while (CanMove(p))
            {
                res[p.Row, p.Column] = true;
                
                if (Board.GetPiece(p.Row, p.Column) != null)
                {
                    break;
                }
                
                p.Row += vertical;
                p.Column += horizontal;
            }
        }
    }
}