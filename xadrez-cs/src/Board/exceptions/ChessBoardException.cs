using System;

namespace Board;

public class ChessBoardException : Exception
{
    public ChessBoardException(string message) : base(message) {}
}