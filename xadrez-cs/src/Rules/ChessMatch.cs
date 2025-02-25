using System;
using System.Collections.Generic;
using Board;
using Application;
using Pieces;
using System.Drawing;

namespace Rules;

public class ChessMatch
{
    public ChessBoard Board;
    public int Turn { get; private set ;}
    public List<Piece> BlackPieces = [];
    public List<Piece> WhitePieces = [];
    public List<Piece> InGamePieces = [];
    public bool Check;
    public bool Active;
    public Colors CurrentPlayer {
        get {
            return (Turn % 2 == 0) ? Colors.Black : Colors.White;
        }
    }

    public ChessMatch()
    {
        this.Board = new ChessBoard();
        this.Turn = 1;
        this.Active = true;
        Board.SetPiece(new King(Colors.Black, Board), new Position(0, 4));
        Board.SetPiece(new King(Colors.White, Board), new Position(7, 4));
        Board.SetPiece(new Rook(Colors.Black, Board), new Position(0, 2));
        Board.SetPiece(new Rook(Colors.Black, Board), new Position(0, 3));
        this.InitialList();
    }

    public void RealizeTurn(Position initial, Position final)
    {
        var endpiece = this.Move(initial, final);

        if (IsInCheck(CurrentPlayer))
        {
            RevertMove(initial, final, endpiece);
            throw new ChessGameException("Cannot realize movement as it puts king in check.");
        }
        else if (IsInCheck(Oponent(CurrentPlayer)))
        {
            Check = true;
        }
        else
        {
            Check = false;
        }

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

    private void InitialList()
    {
        for (int i = 0; i < Board.Row; i++)
        {
            for (int j = 0; j < Board.Column; j++)
            {
                if (Board.GetPiece(i, j) != null)
                {
                    InGamePieces.Add(Board.GetPiece(i, j)!);
                }
            }
        }
    }

    // Posso melhorar a lógica dividindo em métodos menores.
    public Piece? Move(Position position1, Position position2)
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
            InGamePieces.Remove(endPiece);
            WhitePieces.Add(endPiece);
        }
        else if (endPiece != null && endPiece.Color == Colors.Black)
        {
            InGamePieces.Remove(endPiece);
            BlackPieces.Add(endPiece);
        }

        return endPiece;
    }

    // Reverte o movimento caso seja cheque.
    public void RevertMove(Position initial, Position final, Piece? former)
    {
        var p = Board.GetPiece(final)!;

        Board.SetPiece(p, initial);
        var s = Board.RemovePiece(final);
        
        if (former != null)
        {
            Board.SetPiece(former, final);
            if (former.Color == Colors.White)
            {
                WhitePieces.Remove(former);
            }
            else
            {
                BlackPieces.Remove(former);
            }
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

    public void ValidateFinal(Position inicial, Position final)
    {
        if (!Board.GetPiece(inicial)!.CouldMoveTo(final))
        {
            throw new ChessGameException("Selected piece cannot move to this position.");
        }
    }

    public static Colors Oponent(Colors c)
    {
        return (c == Colors.White) ? Colors.Black : Colors.White;
    }

    public King? GetKing(Colors c)
    {
        foreach(Piece p in InGamePieces.Where(p => p.Color == c))
        {
            if (p is King)
            {
                return p as King;
            }
        }
        throw new ChessGameException("There is no king for this game.");
    }

    public bool IsInCheck(Colors color)
    {
        var king = GetKing(color)!;

        foreach (var piece in InGamePieces.Where(p => p.Color != color))
        {
            var possibles = piece.GetMovements();

            if (possibles[king.Position.Row, king.Position.Column] == true)
            {
                return true;
            }
        }
        return false;
    }
}