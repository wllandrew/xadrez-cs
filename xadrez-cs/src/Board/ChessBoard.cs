using System;
using Pieces;
using Pieces;

namespace Board
{
    public class ChessBoard
    {
        public int Row;
        public int Column;
        public Piece[,] Board;

        public ChessBoard(int row = 8, int column = 8)
        {
            this.Row = row;
            this.Column = column;

            this.Board = new Piece[Row, Column];
            this.InitialSetting();
        }

        public Piece GetPiece(int row, int column)
        {
            return this.Board[row, column];
        }

        public void SetPiece(Piece piece, Position pos)
        {
            this.Board[pos.Row, pos.Column] = piece;
            piece.Position = pos;
        }

        public void InitialSetting()
        {
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    Colors color = (i < 4) ? Colors.White : Colors.Black;

                    if (i == 7 || i == 0)
                    {
                        
                    }
                    else if (i == 1 || i == 6)
                    {
                        this.SetPiece(new Pawn(color, this), new Position(i, j));
                    }
                } 
            }
        }
    }
}