using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore.Models
{
    public static class StandardMoveDefinitions
    {
        #region Pawn
        private static ChessPieceMoveDefinition whitePawnInitialFileMoveDefinition;
        private static ChessPieceMoveDefinition blackPawnInitialFileMoveDefinition;
        private static ChessPieceMoveDefinition whitePawnStandardFileMoveDefinition;
        private static ChessPieceMoveDefinition blackPawnStandardFileMoveDefinition;
        private static ChessPieceMoveDefinition whitePawnAttackFileMoveDefinition;
        private static ChessPieceMoveDefinition blackPawnAttackFileMoveDefinition;
        public static ChessPieceMoveDefinition PawnInitialMoveDefinition(ChessPieceColor orientation)
        {
            if (whitePawnInitialFileMoveDefinition == default(ChessPieceMoveDefinition))
                whitePawnInitialFileMoveDefinition = new ChessPieceMoveDefinition(1, 0, 2, ChessPieceMoveDirections.PositiveFile);
            if (blackPawnInitialFileMoveDefinition == default(ChessPieceMoveDefinition))
                blackPawnInitialFileMoveDefinition = new ChessPieceMoveDefinition(1, 0, 2, ChessPieceMoveDirections.NegativeFile);
            return orientation == ChessPieceColor.White ? whitePawnInitialFileMoveDefinition : blackPawnInitialFileMoveDefinition;
        }

        public static ChessPieceMoveDefinition PawnStandardMoveDefinition(ChessPieceColor orientation)
        {
            if (whitePawnStandardFileMoveDefinition == default(ChessPieceMoveDefinition))
                whitePawnStandardFileMoveDefinition = new ChessPieceMoveDefinition(1, 0, 1, ChessPieceMoveDirections.PositiveFile);
            if (blackPawnStandardFileMoveDefinition == default(ChessPieceMoveDefinition))
                blackPawnStandardFileMoveDefinition = new ChessPieceMoveDefinition(1, 0, 1, ChessPieceMoveDirections.NegativeFile);
            return orientation == ChessPieceColor.White ? whitePawnStandardFileMoveDefinition : blackPawnStandardFileMoveDefinition;
        }

        public static ChessPieceMoveDefinition PawnAttackMoveDefinition(ChessPieceColor orientation)
        {
            if (whitePawnAttackFileMoveDefinition == default(ChessPieceMoveDefinition))
                whitePawnAttackFileMoveDefinition = new ChessPieceMoveDefinition(1, 1, 1, ChessPieceMoveDirections.PositiveFile | ChessPieceMoveDirections.PositiveRank);
            if (blackPawnAttackFileMoveDefinition == default(ChessPieceMoveDefinition))
                blackPawnAttackFileMoveDefinition = new ChessPieceMoveDefinition(1, 1, 1, ChessPieceMoveDirections.PositiveFile | ChessPieceMoveDirections.PositiveRank);
            return orientation == ChessPieceColor.White ? whitePawnAttackFileMoveDefinition : blackPawnAttackFileMoveDefinition;
        }
        #endregion

        #region Rook
        private static ChessPieceMoveDefinition rookStandardFileMoveDefinition;
        private static ChessPieceMoveDefinition rookStandardRankMoveDefinition;

        public static ChessPieceMoveDefinition RookStandardFileMoveDefinition(ChessPieceColor orientation)
        {
            if (rookStandardFileMoveDefinition == default(ChessPieceMoveDefinition))
                rookStandardFileMoveDefinition = new ChessPieceMoveDefinition(1, 0, 8, ChessPieceMoveDirections.PositiveFile | ChessPieceMoveDirections.NegativeFile);
            return rookStandardFileMoveDefinition;
        }
        public static ChessPieceMoveDefinition RookStandardRankMoveDefinition(ChessPieceColor orientation)
        {
            if (rookStandardRankMoveDefinition == default(ChessPieceMoveDefinition))
                rookStandardRankMoveDefinition = new ChessPieceMoveDefinition(0, 8, 8, ChessPieceMoveDirections.PositiveRank | ChessPieceMoveDirections.NegativeRank);
            return rookStandardRankMoveDefinition;
        }
        #endregion

        #region Knight
        private static ChessPieceMoveDefinition knightStandardFileMoveDefinition;
        private static ChessPieceMoveDefinition knightStandardRankMoveDefinition;

        public static ChessPieceMoveDefinition KnightStandardFileMoveDefinition(ChessPieceColor orientation)
        {
            if (knightStandardFileMoveDefinition == default(ChessPieceMoveDefinition))
                knightStandardFileMoveDefinition = new ChessPieceMoveDefinition(2, 1, 1, ChessPieceMoveDirections.AscendingDiagonal | ChessPieceMoveDirections.DescendingDiagonal);
            return knightStandardFileMoveDefinition;
        }
        public static ChessPieceMoveDefinition KnightStandardRankMoveDefinition(ChessPieceColor orientation)
        {
            if (knightStandardRankMoveDefinition == default(ChessPieceMoveDefinition))
                knightStandardRankMoveDefinition = new ChessPieceMoveDefinition(1, 2, 1, ChessPieceMoveDirections.AscendingDiagonal | ChessPieceMoveDirections.DescendingDiagonal);
            return knightStandardRankMoveDefinition;
        }
        #endregion

        #region Bishop
        private static ChessPieceMoveDefinition bishopStandardFileMoveDefinition;
        private static ChessPieceMoveDefinition bishopStandardRankMoveDefinition;

        public static ChessPieceMoveDefinition BishopStandardFileMoveDefinition(ChessPieceColor orientation)
        {
            if (bishopStandardFileMoveDefinition == default(ChessPieceMoveDefinition))
                bishopStandardFileMoveDefinition = new ChessPieceMoveDefinition(1, 1, 8, ChessPieceMoveDirections.AscendingDiagonal | ChessPieceMoveDirections.DescendingDiagonal);
            return bishopStandardFileMoveDefinition;
        }
        public static ChessPieceMoveDefinition BishopStandardRankMoveDefinition(ChessPieceColor orientation)
        {
            if (bishopStandardRankMoveDefinition == default(ChessPieceMoveDefinition))
                bishopStandardRankMoveDefinition = new ChessPieceMoveDefinition(1, 1, 8, ChessPieceMoveDirections.AscendingDiagonal | ChessPieceMoveDirections.DescendingDiagonal);
            return bishopStandardRankMoveDefinition;
        }
        #endregion

        #region King
        private static ChessPieceMoveDefinition kingStandardFileMoveDefinition;
        private static ChessPieceMoveDefinition kingStandardRankMoveDefinition;
        private static ChessPieceMoveDefinition kingStandardDiagonalMoveDefinition;

        public static ChessPieceMoveDefinition KingStandardFileMoveDefinition(ChessPieceColor orientation)
        {
            if (kingStandardFileMoveDefinition == default(ChessPieceMoveDefinition))
                kingStandardFileMoveDefinition = new ChessPieceMoveDefinition(1, 0, 1, ChessPieceMoveDirections.File);
            return kingStandardFileMoveDefinition;
        }
        public static ChessPieceMoveDefinition KingStandardRankMoveDefinition(ChessPieceColor orientation)
        {
            if (kingStandardRankMoveDefinition == default(ChessPieceMoveDefinition))
                kingStandardRankMoveDefinition = new ChessPieceMoveDefinition(0, 1, 1, ChessPieceMoveDirections.Rank);
            return kingStandardRankMoveDefinition;
        }
        public static ChessPieceMoveDefinition KingStandardDiagonalMoveDefinition(ChessPieceColor orientation)
        {
            if (kingStandardDiagonalMoveDefinition == default(ChessPieceMoveDefinition))
                kingStandardDiagonalMoveDefinition = new ChessPieceMoveDefinition(1, 1, 1, ChessPieceMoveDirections.AscendingDiagonal | ChessPieceMoveDirections.DescendingDiagonal);
            return kingStandardDiagonalMoveDefinition;
        }
        #endregion

        #region Queen
        private static ChessPieceMoveDefinition queenStandardFileMoveDefinition;
        private static ChessPieceMoveDefinition queenStandardRankMoveDefinition;
        private static ChessPieceMoveDefinition queenStandardDiagonalMoveDefinition;

        public static ChessPieceMoveDefinition QueenStandardFileMoveDefinition(ChessPieceColor orientation)
        {
            if (queenStandardFileMoveDefinition == default(ChessPieceMoveDefinition))
                queenStandardFileMoveDefinition = new ChessPieceMoveDefinition(1, 0, 8, ChessPieceMoveDirections.File);
            return queenStandardFileMoveDefinition;
        }
        public static ChessPieceMoveDefinition QueenStandardRankMoveDefinition(ChessPieceColor orientation)
        {
            if (queenStandardRankMoveDefinition == default(ChessPieceMoveDefinition))
                queenStandardRankMoveDefinition = new ChessPieceMoveDefinition(0, 1, 8, ChessPieceMoveDirections.Rank);
            return queenStandardRankMoveDefinition;
        }
        public static ChessPieceMoveDefinition QueenStandardDiagonalMoveDefinition(ChessPieceColor orientation)
        {
            if (queenStandardDiagonalMoveDefinition == default(ChessPieceMoveDefinition))
                queenStandardDiagonalMoveDefinition = new ChessPieceMoveDefinition(1, 1, 8, ChessPieceMoveDirections.AscendingDiagonal | ChessPieceMoveDirections.DescendingDiagonal);
            return queenStandardDiagonalMoveDefinition;
        }
        #endregion
    }
}
