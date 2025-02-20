using System;

namespace Application;

public class BoardInputException : Exception
{
    public BoardInputException(string message) : base(message) {}
}