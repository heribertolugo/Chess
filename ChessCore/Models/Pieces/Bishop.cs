using ChessCore.Models;
using System;
using System.Collections.Generic;

namespace ChessCore.Pieces
{
    public partial class Bishop : ChessPiece
    {
        private List<ChessPieceMoveDefinition> _allowedMoves;
        public Bishop(BoardCoordinate initialLocation, ChessPieceColor owningPlayerOrientation) : base(initialLocation, owningPlayerOrientation)
        {
            this._allowedMoves = new List<ChessPieceMoveDefinition>();
            this._allowedMoves.Add(StandardMoveDefinitions.BishopStandardFileMoveDefinition(owningPlayerOrientation));
            this._allowedMoves.Add(StandardMoveDefinitions.BishopStandardRankMoveDefinition(owningPlayerOrientation));
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
