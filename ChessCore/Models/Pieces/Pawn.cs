using ChessCore.Models;
using System;
using System.Collections.Generic;

namespace ChessCore.Pieces
{
    public partial class Pawn : ChessPiece
    {
        private List<ChessPieceMoveDefinition> _allowedMoves;

        public Pawn(BoardCoordinate initialCoordinate, ChessPieceColor owningPlayerOrientation) : base(initialCoordinate, owningPlayerOrientation)
        {
            this._allowedMoves = new List<ChessPieceMoveDefinition>();
            this._allowedMoves.Add(StandardMoveDefinitions.PawnInitialMoveDefinition(this.OwningPlayerOrientation));
        }
        public bool AttackTo(BoardCoordinate coordinate)
        {
            bool moved = false;
            this._allowedMoves.Add(StandardMoveDefinitions.PawnAttackMoveDefinition(this.OwningPlayerOrientation));

            moved = this.MoveTo(coordinate);

            this._allowedMoves.Remove(StandardMoveDefinitions.PawnAttackMoveDefinition(this.OwningPlayerOrientation));
            return moved;
        }

        public override bool MoveTo(BoardCoordinate coordinate)
        {
            bool isFirstMove = this.CurrentLocation == this.MoveHistory[0];
            bool hasMoved = base.MoveTo(coordinate);

            if (isFirstMove && hasMoved)
            {
                this._allowedMoves.Remove(StandardMoveDefinitions.PawnInitialMoveDefinition(this.OwningPlayerOrientation));
                this._allowedMoves.Add(StandardMoveDefinitions.PawnStandardMoveDefinition(this.OwningPlayerOrientation));
            }

            return hasMoved;
        }

        public override string AlgebraicNotationName
        {
            get
            {
                return base.AlgebraicNotationName.ToLower();
            }
            set
            {
                base.AlgebraicNotationName = value;
            }
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
