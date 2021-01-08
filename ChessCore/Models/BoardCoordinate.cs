using System;

namespace ChessCore.Models
{
    [System.Runtime.InteropServices.ComVisible(true)]
    [Serializable]
    public struct BoardCoordinate
    {
        public BoardCoordinate(RankCoordinate rankCoordinate, FileCoordinate fileCoordinate)
        {
            this.Rank = rankCoordinate;
            this.File = fileCoordinate;
        }
        public RankCoordinate Rank { get; set; }
        public FileCoordinate File { get; set; }

        //public static BoardCoordinate operator +(BoardCoordinate b1, BoardCoordinate b2)
        //{
        //    return new BoardCoordinate((int)b1.File + (int)b2.File,
        //       (int)b1.Rank + (int)b2.Rank);
        //}

        public static bool operator ==(BoardCoordinate b1, BoardCoordinate b2)
        {
            return (b1.Rank == b2.Rank) && (b1.File == b2.File);
        }

        public static bool operator !=(BoardCoordinate b1, BoardCoordinate b2)
        {
            return !(b1 == b2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
