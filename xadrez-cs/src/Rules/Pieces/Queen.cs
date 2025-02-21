using System;
using Board;

namespace Pieces
{
    public class Queen : Piece
    {
        public Queen(Colors color, ChessBoard board) : base(color, board) {}

        public override string ToString()
        {
            return "Q";
        }

        public override bool[,] GetMovements()
        {
            var res = new bool[Board.Row, Board.Column];

            Line(ref res);
            Cross(ref res);

            return res;
        }

        public bool[,] Line(ref bool[,] res)
        {

            TraverseLine(ref res, 1, 'c');
            TraverseLine(ref res, -1, 'c');
            TraverseLine(ref res, 1, 'r');
            TraverseLine(ref res, -1, 'r');

            return res;
        }

        private void TraverseLine(ref bool[,] res, int change, char line)
        {
            Position p;
            if (line == 'c')
            {
                p = new Position(Position.Row, Position.Column + change);
            }
            else
            {
                p = new Position(Position.Row + change, Position.Column);
            }
            while (CanMove(p))
            {
                res[p.Row, p.Column] = true;

                if (Board.GetPiece(p) != null)
                {
                    break;
                }

                if (line == 'c')
                {
                    p.Column += change;
                }
                else 
                {
                    p.Row += change;
                }
            }
        }
        public bool[,] Cross(ref bool[,] res)
        {

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