using System;
using Application;
using Board;
using Rules;

namespace Principal;

class Program
{
    static void Main(string[] args)
    {
        var match = new ChessMatch();

        match.Routine();
    }
}