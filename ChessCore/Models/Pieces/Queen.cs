using ChessCore.Models;
using System;
using System.Collections.Generic;

namespace ChessCore.Pieces
{
    public partial class Queen : ChessPiece
    {
        private List<ChessPieceMoveDefinition> _allowedMoves;
        public Queen(BoardCoordinate initialLocation, ChessPieceColor owningPlayerOrientation) : base(initialLocation, owningPlayerOrientation)
        {
            this._allowedMoves = new List<ChessPieceMoveDefinition>();
            this._allowedMoves.Add(StandardMoveDefinitions.QueenStandardFileMoveDefinition(owningPlayerOrientation));
            this._allowedMoves.Add(StandardMoveDefinitions.QueenStandardRankMoveDefinition(owningPlayerOrientation));
            this._allowedMoves.Add(StandardMoveDefinitions.QueenStandardDiagonalMoveDefinition(owningPlayerOrientation));
        }

        public override IReadOnlyList<ChessPieceMoveDefinition> AllowedMoves
        {
            get
            {
                return this._allowedMoves;
            }
        }
    }
}
