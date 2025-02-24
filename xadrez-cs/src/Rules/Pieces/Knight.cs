using System;
using Board;

namespace Pieces
{
    public class Knight : Piece
    {
        public Knight(Colors color, ChessBoard board) : base(color, board) {}

        public override string ToString()
        {
            return "N";
        }

        public override bool[,] GetMovements()
        {
            var res = new bool[Board.Row, Board.Column];
            // Define o tamanho das possiveis mudanças pequenas e grandes
            var bigChange = new int[] { -2, 2 };
            var smallChange = new int[] { -1, 1 };

            // Implementa a lógica de mover em l, checando apenas as posições correspondentes
            MoveL(Position, ref res, bigChange, smallChange);
            MoveL(Position, ref res, smallChange, bigChange);

            return res;
        }

        // Problema: checa a mesma posição mais de uma vez.
        private void MoveL(Position p, ref bool[,] movements, int[] big, int[] small) 
        {
            foreach (var i in big)
            {
                foreach (var j in small)
                {
                    if (i != j)
                    {
                        var currentPos = new Position(p.Row + i, p.Column + j);

                        if (Board.IsValid(currentPos))
                        {
                            movements[currentPos.Row, currentPos.Column] = CanMove(currentPos);
                        }
                    }
                }
            }
        }
    }
}