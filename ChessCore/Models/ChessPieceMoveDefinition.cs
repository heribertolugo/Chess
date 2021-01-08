namespace ChessCore.Models
{
    public struct ChessPieceMoveDefinition
    {
        public ChessPieceMoveDefinition(int fileMoveSteps, int rankMoveSteps, int maxMove, ChessPieceMoveDirections moveDirections)
        {
            this.FileMoveSteps = fileMoveSteps;
            this.RankMoveSteps = rankMoveSteps;
            this.MaxMove = maxMove;
            this.MoveDirections = moveDirections;
        }
        public int MaxMove { get; }
        public int FileMoveSteps { get; }
        public int RankMoveSteps { get; }
        public ChessPieceMoveDirections MoveDirections { get; }
        
        public static bool operator ==(ChessPieceMoveDefinition d1, ChessPieceMoveDefinition d2)
        {
            return (d1.FileMoveSteps == d2.FileMoveSteps) && (d1.MaxMove == d2.MaxMove) 
                && (d1.MoveDirections == d2.MoveDirections) && (d1.RankMoveSteps == d2.RankMoveSteps);
        }

        public static bool operator !=(ChessPieceMoveDefinition d1, ChessPieceMoveDefinition d2)
        {
            return !(d1 == d2);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
