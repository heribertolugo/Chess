using System;
using System.Windows.Forms;
using ChessCore.Models;
using GuiTest.Models;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace GuiTest.Pieces
{
    public class UiPawn : UiChessPiece//, IHandleChessPiece
    {
        //private IChessPiece piece;
        //private UiPawn()
        //{

        //}
        public UiPawn(BoardCoordinate boardCoordinate, ChessPieceColor playerOrientation)
            : base(new ChessCore.Pieces.Pawn(boardCoordinate, playerOrientation))
        {

        }

        public UiPawn()
        {
        }

        public override Type PieceType
        {
            get
            {
                return typeof(ChessPiece);
            }
        }

        ///// <summary>
        ///// For Designer only
        ///// </summary>
        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override void DesignerInitialized(BoardCoordinate boardCoordinate, ChessPieceColor playerOrientation)
        //{
        //    this.Piece = new ChessCore.Pieces.Pawn(boardCoordinate, playerOrientation);
        //    this.InitialBoardCoordinate = boardCoordinate;
        //    this.OwningPlayerOrientation = playerOrientation;
        //    //var host = GetService(typeof(IDesignerHost)) as IDesignerHost;
        //    //var button = host.CreateComponent(typeof(ChessCore.Pieces.Pawn), "someName") as ChessCore.Pieces.Pawn;

        //    //((IDesignerHost)this.Site.GetService(typeof(IDesignerHost))).Container.Add(this.Piece as IComponent, "bobo");
        //}
        
    }
}
