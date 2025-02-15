using System;
using Application;
using Board;

namespace Principal;

class Program
{
    static void Main(string[] args)
    {
        var cb = new ChessBoard();

        Screen.PrintBoard(cb);
    }
}