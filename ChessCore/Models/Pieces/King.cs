using ChessCore.Models;
using System;
using System.Collections.Generic;

namespace ChessCore.Pieces
{
    public partial class King : ChessPiece
    {
        private List<ChessPieceMoveDefinition> _allowedMoves;
        public King(BoardCoordinate initialLocation, ChessPieceColor owningPlayerOrientation) : base(initialLocation, owningPlayerOrientation)
        {
            this._allowedMoves = new List<ChessPieceMoveDefinition>();
            this._allowedMoves.Add(StandardMoveDefinitions.KingStandardFileMoveDefinition(owningPlayerOrientation));
            this._allowedMoves.Add(StandardMoveDefinitions.KingStandardRankMoveDefinition(owningPlayerOrientation));
            this._allowedMoves.Add(StandardMoveDefinitions.KingStandardDiagonalMoveDefinition(owningPlayerOrientation));
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
