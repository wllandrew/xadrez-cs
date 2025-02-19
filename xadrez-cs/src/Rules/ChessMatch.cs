using System;
using System.Collections.Generic;
using Board;
using Application;

namespace Rules;

public class ChessMatch
{
    public ChessBoard Board;
    public int Turn;
    public List<Piece> BlackPieces = new List<Piece>();
    public List<Piece> WhitePieces = new List<Piece>();
    
    public ChessMatch()
    {
        this.Board = new ChessBoard();
        this.Turn = 0;
    }

    public void Routine()
    {
        // Show Board
        Screen.PrintBoard(this.Board);
        // Show Captured Pieces
        ShowList(this.WhitePieces, Colors.White);
        ShowList(this.BlackPieces, Colors.Black);
        // Ask for move input
        // Implement input exceptions
        // Show possible moves
        // Implement input exceptions
        // Move pieces
    }

    public static void ShowList(List<Piece> list, Colors color)
    {
        if (color == Colors.White)
        {
            Console.Write("Black captured: [ ");                
        }
        else
        {
            Console.Write("White captured: [ ");        
        }
        foreach (Piece piece in list)
        {
            Console.Write(piece + " ");
        }
        System.Console.WriteLine("]");
    }

    public void Move()
    {

    }

}