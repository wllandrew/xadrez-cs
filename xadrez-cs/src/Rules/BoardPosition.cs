using System;
using Board;

namespace Rules;

public struct BoardPosition(char row, int column)
{
    public char Row = row;
    public int Column = column;

    // Usar essa lógica escala melhor do que um enum
    public readonly Position ToPosition()
    {
        return new Position(8 - this.Column, this.Row - 'a');
    }
}