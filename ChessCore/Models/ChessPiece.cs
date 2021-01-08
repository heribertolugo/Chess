using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessCore.Models
{
    public abstract class ChessPiece : IChessPiece
    {
        private List<BoardCoordinate> _moves;
        private string _algebraicNotationName;
        private string _name;

        public ChessPiece(BoardCoordinate initialLocation, ChessPieceColor owningPlayerOrientation)
        {
            this._moves = new List<BoardCoordinate>();
            this._moves.Add(initialLocation);
            this.OwningPlayerOrientation = owningPlayerOrientation;
            this._name = this.GetType().Name;
            this._algebraicNotationName = this.Name[0].ToString();
        }
        public virtual ChessPieceColor OwningPlayerOrientation { get; }
        public virtual string AlgebraicNotationName { get { return this._algebraicNotationName; } set { this._algebraicNotationName = value; } }

        public virtual BoardCoordinate CurrentLocation
        {
            get
            {
                return this._moves[this._moves.Count - 1];
            }
        }

        public virtual IReadOnlyList<BoardCoordinate> MoveHistory
        {
            get
            {
                return this._moves;
            }
        }

        public virtual string Name { get { return this._name; } set { this._name = value; } }

        public abstract IReadOnlyList<ChessPieceMoveDefinition> AllowedMoves { get; } 

        public virtual bool MoveTo(BoardCoordinate coordinate)
        {
            bool isValidMove = this.IsValidMove(coordinate) && coordinate != this.CurrentLocation;

            if (isValidMove)
                this._moves.Add(coordinate);

            return isValidMove;
        }

        public virtual bool IsValidMove(BoardCoordinate newCoordinate)
        {
            bool isValidMove = false;

            foreach(ChessPieceMoveDefinition moveDefinition in this.AllowedMoves)
            {
                int maxSteps = moveDefinition.MaxMove;
                int fileSteps = (int)newCoordinate.File - (int)this.CurrentLocation.File;
                int rankSteps = (int)newCoordinate.Rank - (int)this.CurrentLocation.Rank;
                ChessPieceMoveDirections directionMoved = ChessPieceMoveDirections.None;

                // check flags for direction moved
                directionMoved |= (fileSteps > 0 ? ChessPieceMoveDirections.PositiveFile : (fileSteps < 0 ? ChessPieceMoveDirections.NegativeFile : ChessPieceMoveDirections.None));
                directionMoved |= (rankSteps > 0 ? ChessPieceMoveDirections.PositiveRank : (rankSteps < 0 ? ChessPieceMoveDirections.NegativeRank : ChessPieceMoveDirections.None));

                if (!moveDefinition.MoveDirections.HasFlag(directionMoved)) continue;
                
                if (moveDefinition.FileMoveSteps == 0 && moveDefinition.RankMoveSteps != 0)
                {
                    if ((fileSteps == 0 && moveDefinition.FileMoveSteps == 0)
                     && ((Math.Abs(rankSteps) % moveDefinition.RankMoveSteps == 0) && (Math.Abs(rankSteps) / moveDefinition.RankMoveSteps) <= maxSteps))
                    {
                        isValidMove = true;
                        break;
                    }
                } else if (moveDefinition.FileMoveSteps != 0 && moveDefinition.RankMoveSteps == 0)
                {
                    if ((rankSteps == 0 && moveDefinition.RankMoveSteps == 0)
                     && ((Math.Abs(fileSteps) % moveDefinition.FileMoveSteps == 0) && (Math.Abs(fileSteps) / moveDefinition.FileMoveSteps) <= maxSteps))
                    {
                        isValidMove = true;
                        break;
                    }
                }
                else if (moveDefinition.FileMoveSteps != 0 && moveDefinition.RankMoveSteps != 0)
                {
                    if ( ((Math.Abs(rankSteps) % moveDefinition.RankMoveSteps == 0) && (Math.Abs(rankSteps) / moveDefinition.RankMoveSteps) <= maxSteps)
                     && ((Math.Abs(fileSteps) % moveDefinition.FileMoveSteps == 0) && (Math.Abs(fileSteps) / moveDefinition.FileMoveSteps) <= maxSteps) 
                     && (Math.Abs(fileSteps) / moveDefinition.FileMoveSteps == Math.Abs(rankSteps) / moveDefinition.RankMoveSteps))
                    {
                        isValidMove = true;
                        break;
                    }
                }
                else if (moveDefinition.FileMoveSteps == 0 && moveDefinition.RankMoveSteps == 0)
                {

                }
            }

            return isValidMove;
        }
    }

    public static class ChessPieceExtensionMethods
    {
        public static IEnumerable<IGrouping<ChessPieceMoveDirections , IEnumerable<BoardCoordinate>>> AvailableMoves(this IChessPiece chessPiece, IChessBoard board)
        {
            //board.CoordinateExists(coord);
            return new List<KeyValuePair<ChessPieceMoveDirections, IEnumerable<BoardCoordinate>>>().GroupBy(k => k.Key, k => k.Value);
        }
    }
}
