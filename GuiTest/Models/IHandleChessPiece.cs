using ChessCore.Models;
using System;

namespace GuiTest.Models
{
    interface IHandleChessPiece
    {
        //IChessPiece Piece { get; }
        event PieceMovedEventHandler RaisePieceMoved;
        event PieceMovedEventHandler RaisePieceMoving;
        event PieceAttackedEventHandler RaisePieceAttacked;
        event PieceAttackingEventHandler RaisePieceAttacking;
        void OnRaisePieceMoved(PieceMoveEventArgs e);
        void OnRaisePieceMoving(PieceMoveEventArgs e);
        void OnRaisePieceAttacked(PieceAttackEventArgs e);
        void OnRaisePieceAttacking(PieceAttackEventArgs e);
    }

    public delegate void PieceMovedEventHandler(object sender, PieceMoveEventArgs e);
    public delegate void PieceMovingEventHandler(object sender, PieceMoveEventArgs e);
    public delegate void PieceAttackedEventHandler(object sender, PieceAttackEventArgs e);
    public delegate void PieceAttackingEventHandler(object sender, PieceAttackEventArgs e);
    public class PieceMoveEventArgs : EventArgs
    {
        public PieceMoveEventArgs(bool isValid, BoardCoordinate from, BoardCoordinate to)
        {
            this.IsValidMove = IsValidMove;
            this.From = from;
            this.To = to;
        }
        public bool IsValidMove { get; }
        public BoardCoordinate From { get; }
        public BoardCoordinate To { get; }
    }
    public class PieceAttackEventArgs : EventArgs
    {
        public PieceAttackEventArgs(bool isValid, BoardCoordinate from, BoardCoordinate attackAt, UiChessPiece attacker, UiChessPiece attackee)
        {
            this.IsValid = isValid;
            this.From = from;
            this.AttackCoordinates = attackAt;
            this.Attacker = attacker;
            this.Attackee = attackee;
        }
        public bool IsValid { get; set; }
        public BoardCoordinate From { get; }
        public BoardCoordinate AttackCoordinates { get; }
        public UiChessPiece Attacker { get; }
        public UiChessPiece Attackee { get; }
    }
}
