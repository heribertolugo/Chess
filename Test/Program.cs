using ChessCore.Models;
using ChessCore.Pieces;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardCoordinate initialCord = new BoardCoordinate(RankCoordinate.One, FileCoordinate.B);
            IChessPiece piece = new Knight(initialCord, ChessPieceColor.White);

            bool pieceMoved = piece.MoveTo(new BoardCoordinate(RankCoordinate.Four, FileCoordinate.C));
            Console.WriteLine(pieceMoved);
            pieceMoved = piece.MoveTo(new BoardCoordinate(RankCoordinate.One, FileCoordinate.B));
            Console.WriteLine(pieceMoved);
            pieceMoved = piece.MoveTo(new BoardCoordinate(RankCoordinate.Three, FileCoordinate.A));
            Console.WriteLine(pieceMoved);
            Console.ReadKey();
        }
    }
}
