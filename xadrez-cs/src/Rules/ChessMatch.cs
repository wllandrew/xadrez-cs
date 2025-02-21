using System;
using System.Collections.Generic;
using Board;
using Application;
using Pieces;

namespace Rules;

public class ChessMatch
{
    public ChessBoard Board;
    public int Turn { get; private set ;}
    public List<Piece> BlackPieces = [];
    public List<Piece> WhitePieces = [];
    public bool Active;
    
    public ChessMatch()
    {
        this.Board = new ChessBoard();
        this.Turn = 1;
        this.Active = true;
        this.InitialSetting();
    }

    public void RealizeTurn(Position initial, Position final)
    {
        this.Move(initial, final);
        this.Turn++;
    }

    public void InitialSetting()
    {
        for (int i = 0; i < Board.Column; i++)
        {
            Board.SetPiece(new Pawn(Colors.White, Board), new Position(6, i));
            Board.SetPiece(new Pawn(Colors.Black, Board), new Position(1, i));
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

    public void ValidateInitial(Position p)
    {
        if (Board.GetPiece(p) == null)
        {
            throw new ChessGameException("Selected position does not match a valid piece.");
        }
        if (Board.GetPiece(p)!.Color == Colors.White && Turn % 2 != 1
            || Board.GetPiece(p)!.Color == Colors.Black && Turn % 2 != 0)
        {
            throw new ChessGameException("Selected piece color does not match the current turn's color.");
        }
        if (!Board.GetPiece(p)!.IsThereMovements())
        {
            throw new ChessGameException("There is no possible movements for this piece.");
        }
    }

}