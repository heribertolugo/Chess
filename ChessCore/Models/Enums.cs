using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore.Models
{
    //class Enums
    //{
    //}

    public enum FileCoordinate
    {
        None = 0,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H
    }

    public enum RankCoordinate
    {
        None = 0,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight
    }

    public enum ChessPieceColor
    {
        None = 0,
        White,
        Black
    }

    public enum ChessPieceMoveType
    {
        None = 0,
        Individual,
        Concurrent
    }

    public enum StandarChessPieceName
    {
        None = 0,
        Pawn,
        Rook,
        Knight,
        Bishop,
        King,
        Queen
    }

    public enum ChessPieceMoveDirections
    {
        None = 0,
        PositiveFile = 1,
        NegativeFile = 2,
        PositiveRank = 4,
        NegativeRank = 8,
        File = PositiveFile | NegativeFile,
        Rank = PositiveRank | NegativeRank,
        Diagonal_PositiveFileNegativeRank = PositiveFile | NegativeRank,
        /// <summary>
        /// Diagonal_PositiveFileNegativeRank
        /// </summary>
        Diagonal_PFNR = Diagonal_PositiveFileNegativeRank,
        Diagonal_PositiveFilePositiveRank = PositiveFile | PositiveRank,
        /// <summary>
        /// Diagonal_PositiveFilePositiveRank
        /// </summary>
        Diagonal_PFPR = Diagonal_PositiveFilePositiveRank,
        Diagonal_NegativeFilePositiveRank = NegativeFile | PositiveRank,
        /// <summary>
        /// Diagonal_NegativeFilePositiveRank
        /// </summary>
        Diagonal_NFPR = Diagonal_NegativeFilePositiveRank,
        Diagonal_NegativeFileNegativeRank = NegativeFile | NegativeRank,
        /// <summary>
        /// Diagonal_NegativeFileNegativeRank
        /// </summary>
        Diagonal_NFNR = Diagonal_NegativeFileNegativeRank,
        AscendingDiagonal = Diagonal_PFPR | Diagonal_NFNR,
        DescendingDiagonal = Diagonal_NFPR | Diagonal_PFNR,
        All = File | Rank | AscendingDiagonal | DescendingDiagonal
    }
}
