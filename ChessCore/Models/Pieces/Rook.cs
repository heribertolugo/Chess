using ChessCore.Models;
using System;
using System.Collections.Generic;

namespace ChessCore.Pieces
{
    public partial class Rook : ChessPiece
    {
        private List<ChessPieceMoveDefinition> _allowedMoves;
        public Rook(BoardCoordinate initialLocation, ChessPieceColor owningPlayerOrientation) :base(initialLocation, owningPlayerOrientation)
        {
            this._allowedMoves = new List<ChessPieceMoveDefinition>();
            this._allowedMoves.Add(StandardMoveDefinitions.RookStandardFileMoveDefinition(owningPlayerOrientation));
            this._allowedMoves.Add(StandardMoveDefinitions.RookStandardRankMoveDefinition(owningPlayerOrientation));
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
