using System;
using System.Collections.Generic;
using Board;
using Application;
using Pieces;

namespace Rules;

public class ChessMatch
{
    public ChessBoard Board;
    public int Turn;
    public List<Piece> BlackPieces = [];
    public List<Piece> WhitePieces = [];
    public bool Active;
    
    public ChessMatch()
    {
        this.Board = new ChessBoard();
        this.Turn = 0;
        this.Active = true;
        Board.SetPiece(new King(Colors.White, Board), new Position(1, 3)); 
    }

    public void InitialSetting()
    {
        for (int i = 0; i < Board.Row; i++)
        {
            Board.Board[1, i] = new Pawn(Colors.Black, Board);
            Board.Board[6, i] = new Pawn(Colors.White, Board);
        }

        Board.SetPiece(new Rook(Colors.Black, Board), new Position(0, 0));
        Board.SetPiece(new Knight(Colors.Black, Board), new Position(0, 1));
        Board.SetPiece(new Bishop(Colors.Black, Board), new Position(0, 2));
        Board.SetPiece(new Queen(Colors.Black, Board), new Position(0, 3));
        Board.SetPiece(new King(Colors.Black, Board), new Position(0, 4));
        Board.SetPiece(new Bishop(Colors.Black, Board), new Position(0, 5));
        Board.SetPiece(new Knight(Colors.Black, Board), new Position(0, 6));
        Board.SetPiece(new Rook(Colors.Black, Board), new Position(0, 7));

        Board.SetPiece(new Rook(Colors.White, Board), new Position(7, 0));
        Board.SetPiece(new Knight(Colors.White, Board), new Position(7, 1));
        Board.SetPiece(new Bishop(Colors.White, Board), new Position(7, 2));
        Board.SetPiece(new Queen(Colors.White, Board), new Position(7, 3));
        Board.SetPiece(new King(Colors.White, Board), new Position(7, 4));
        Board.SetPiece(new Bishop(Colors.White, Board), new Position(7, 5));
        Board.SetPiece(new Knight(Colors.White, Board), new Position(7, 6));
        Board.SetPiece(new Rook(Colors.White, Board), new Position(7, 7));
    }

    public void Move(Position position1, Position position2)
    {
        var startPiece = Board.RemovePiece(position1);
        var endPiece = Board.RemovePiece(position2);

        if (position1.Equals(position2) || startPiece == null)
        {
            throw new BoardInputException("Input piece is null");
        }

        Board.SetPiece(startPiece!, position2);

        if (endPiece != null && endPiece.Color == Colors.White)
        {
            WhitePieces.Add(endPiece);
        }
        else if (endPiece != null && endPiece.Color == Colors.Black)
        {
            BlackPieces.Add(endPiece);
        }
    }

}