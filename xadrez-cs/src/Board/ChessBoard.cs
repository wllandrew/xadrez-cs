using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        }
    }
}