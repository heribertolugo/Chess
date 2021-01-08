using ChessCore.Models;
using System;
using System.Collections.Generic;

namespace ChessCore.Pieces
{
    public partial class Knight : ChessPiece
    {
        private List<ChessPieceMoveDefinition> _allowedMoves;

        public Knight(BoardCoordinate initialLocation, ChessPieceColor owningPlayerOrientation) : base(initialLocation, owningPlayerOrientation)
        {
            this._allowedMoves = new List<ChessPieceMoveDefinition>();
            this._allowedMoves.Add(StandardMoveDefinitions.KnightStandardFileMoveDefinition(owningPlayerOrientation));
            this._allowedMoves.Add(StandardMoveDefinitions.KnightStandardRankMoveDefinition(owningPlayerOrientation));
            base.AlgebraicNotationName = "N";
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
