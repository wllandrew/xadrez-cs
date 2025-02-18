using System;
using Board;

namespace Rules;

public struct BoardPosition
{
    public char Row;
    public int Column;

    public BoardPosition(char row, int column)
    {
        this.Row = row;
        this.Column = column;
    }

    // Usar essa lógica escala melhor do que um enum
    public Position ToPosition()
    {
        return new Position(this.Row - 'a' , 8 - this.Column);
    }
}