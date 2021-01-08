using System.Collections.Generic;

namespace ChessCore.Models
{
    public interface IChessPiece
    {
        bool MoveTo(BoardCoordinate coordinate);
        BoardCoordinate CurrentLocation { get; }
        IReadOnlyList<BoardCoordinate> MoveHistory { get; }
        string AlgebraicNotationName { get; set; }
        string Name { get; set; }
        IReadOnlyList<ChessPieceMoveDefinition> AllowedMoves { get; }
        ChessPieceColor OwningPlayerOrientation { get; }
    }
}
