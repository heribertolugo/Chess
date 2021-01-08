using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessCore.Models;
using System.ComponentModel;
using System.Drawing;
using System.ComponentModel.Design;

namespace GuiTest.Models
{

    [Designer(typeof(UiChessPieceDesigner))]
    [DesignerCategory("Component")]
    public abstract class UiChessPiece : Label, IHandleChessPiece, IChessPiece
    {
        private IChessPiece _piece = null;
        private ChessPieceColor _playerOrientation;
        //private Control _chessboard;
        private BoardCoordinate _initialCoordinate;
        //*** Drag and Drop
        private Point myOrigin;
        private Point mouseClickOrigin;
        private Control myParent;
        private int myZ_order;
        private bool isGrabbed;
        //***End Drag and Drop

        public UiChessPiece(IChessPiece piece)
        {
            this._piece = piece;
            //this._chessboard = chessboard;
        }

        /// <summary>
        /// For Designer only
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UiChessPiece()
        {
                MessageBox.Show((this.InitialBoardCoordinate == default(BoardCoordinate)).ToString());

            if (this._piece == null && this.InitialBoardCoordinate != default(BoardCoordinate) &&
                this.OwningPlayerOrientation != default(ChessPieceColor))
            {
                this._piece = (IChessPiece)System.ComponentModel.TypeDescriptor.CreateInstance(
                            provider: null, // use standard type description provider, which uses reflection
                            objectType: this.PieceType,
                            argTypes: new Type[] { typeof(BoardCoordinate), typeof(ChessPieceColor) },
                            args: new object[] { this.InitialBoardCoordinate, this.OwningPlayerOrientation }
                        );
            }
        }
        /// <summary>
        /// For Designer only
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IChessPiece Piece
        {
            set
            {
                if (this.DesignMode)
                {
                    this._piece = value;

                }
            }
            get
            {
                return this._piece;
            }
        }
        //public abstract void DesignerInitialized(BoardCoordinate boardCoordinate, ChessPieceColor playerOrientation);
        public abstract Type PieceType { get; }
        #region IChessPiece

        public string AlgebraicNotationName
        {
            get
            {

                return this._piece.AlgebraicNotationName;
            }

            set
            {
                this._piece.AlgebraicNotationName = value;
            }
        }

        public IReadOnlyList<ChessPieceMoveDefinition> AllowedMoves
        {
            get
            {
                return this._piece.AllowedMoves;
            }
        }

        public BoardCoordinate CurrentLocation
        {
            get
            {
                return this._piece.CurrentLocation;
            }
        }

        public IReadOnlyList<BoardCoordinate> MoveHistory
        {
            get
            {
                return this._piece.MoveHistory;
            }
        }

        public ChessPieceColor OwningPlayerOrientation
        {
            get
            {
                return this._playerOrientation;
            }
            set
            {
                this._playerOrientation = value;
            }
        }
        public BoardCoordinate InitialBoardCoordinate
        {
            get { return this._initialCoordinate; }
            set { this._initialCoordinate = value; }
        }
        string IChessPiece.Name
        {
            get
            {
                return this._piece.Name;
            }
            set
            {
                this._piece.Name = value;
            }
        }

        public bool MoveTo(BoardCoordinate coordinate)
        {
            PieceMoveEventArgs eventArgs;
            bool piecemoved = this._piece.MoveTo(coordinate);
            eventArgs = new PieceMoveEventArgs(piecemoved, coordinate, coordinate);

            this.RaisePieceMoving(this, eventArgs);

            if (piecemoved)
            {
                // change parent
            }

            this.RaisePieceMoved(this, eventArgs);

            return piecemoved;
        }
        #endregion

        #region IHandleChessPiece
        public ChessPieceColor PlayerOrientation { get { return this._piece.OwningPlayerOrientation; } }
        //public abstract IChessPiece Piece { get; set; }
        public event PieceMovedEventHandler RaisePieceMoved;
        public event PieceMovedEventHandler RaisePieceMoving;
        public event PieceAttackedEventHandler RaisePieceAttacked;
        public event PieceAttackingEventHandler RaisePieceAttacking;

        public virtual void OnRaisePieceMoved(PieceMoveEventArgs e)
        {

            PieceMovedEventHandler handler = RaisePieceMoved;

            if (handler != null)
            {

                handler(this, e);
            }
        }

        public virtual void OnRaisePieceMoving(PieceMoveEventArgs e)
        {

            PieceMovedEventHandler handler = RaisePieceMoving;

            if (handler != null)
            {

                handler(this, e);
            }
        }

        public void OnRaisePieceAttacked(PieceAttackEventArgs e)
        {
            PieceAttackedEventHandler handler = RaisePieceAttacked;

            if (handler != null)
            {

                handler(this, e);
            }
        }

        public void OnRaisePieceAttacking(PieceAttackEventArgs e)
        {
            PieceAttackingEventHandler handler = RaisePieceAttacking;

            if (handler != null)
            {
                handler(this, e);
                if (e.IsValid)
                {
                    PieceAttackEventArgs e2 = new PieceAttackEventArgs(e.IsValid,
                        new BoardCoordinate(RankCoordinate.None, FileCoordinate.None),
                        e.AttackCoordinates, e.Attacker, e.Attackee);
                    e.Attackee.RaisePieceAttacked(this, e2);
                }
            }
        }
        #endregion

        #region Drag and Drop
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.ImGrabbed();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.isGrabbed)
                this.ImMoving();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        private void ImGrabbed()
        {
            this.isGrabbed = true;
            if (this.Parent != this.FindForm())
            {
                this.MakeFormMyParent();
                this.Location = this.GetMyLocationRelativeToForm();
                this.BringToFront();
            }
        }

        private void ImMoving()
        {
            Point mouseLocation = Cursor.Position;
            int xOffset = this.mouseClickOrigin.X - this.Location.X;
            int yOffset = this.mouseClickOrigin.Y - this.Location.Y;

            this.Location = new Point(mouseLocation.X - xOffset, mouseLocation.Y - yOffset);

            this.mouseClickOrigin = mouseLocation;
        }

        private void ImDropped()
        {
            PieceAttackEventArgs attackingEventArgs = null;
            Point dropPoint = this.GetMyLocationRelativeToForm();
            //Control myNewParent = this.GetFirstControlOfTypeAtPoint(this._chessboard, dropPoint, typeof(IChessboardTile));
            Control myNewParent = this.FindForm().GetChildAtPoint(dropPoint);
            IChessboardTile myNewTile = myNewParent as IChessboardTile;
            if (myNewParent == null || myNewTile == null) return;
            BoardCoordinate newTileCoordinate = new BoardCoordinate(myNewTile.Rank, myNewTile.File);
            bool legalMove = this.MoveTo(newTileCoordinate);
            UiChessPiece occupyingPiece = null;
            if (legalMove)
            {
                // find other chess piece in tile and if present
                occupyingPiece = this.GetFirstControlOfTypeAtPoint(this.FindForm(), dropPoint, typeof(UiChessPiece)) as UiChessPiece;

                // raise attack event
                if (occupyingPiece != null)
                {
                    attackingEventArgs = new PieceAttackEventArgs(true, this.CurrentLocation, newTileCoordinate, this, occupyingPiece);
                    this.RaisePieceAttacking(this, attackingEventArgs);
                }

                myNewParent.Controls.Add(this);
                this.BringToFront();
                this.Dock = DockStyle.Fill;


                if (occupyingPiece != null)
                {
                    this.RaisePieceAttacked(this, attackingEventArgs);
                }
            }
            else
            {
                // animate back to original tile
            }

        }

        private void MakeFormMyParent()
        {
            this.Parent.Controls.Remove(this);
            this.FindForm().Controls.Add(this);
        }

        private void AssignMyParentByLocation(Point newParentLocation)
        {

        }

        private Point GetMyLocationRelativeToForm()
        {
            Rectangle myRectangle = this.RectangleToScreen(this.DisplayRectangle);
            Rectangle formsRectangle = this.RectangleToScreen(this.FindForm().DisplayRectangle);

            return new Point(formsRectangle.X - myRectangle.X, formsRectangle.Y - myRectangle.Y);
        }

        /// <summary>
        /// Finds the first control which implements IChessBoardTile at the specified point in the given parent control
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        private Control GetFirstControlOfTypeAtPoint(Control parent, Point location, Type T)
        {
            //Control controlAtPoint =  parent.GetChildAtPoint(location);



            //return controlAtPoint as typeof(T);
            foreach (Control control in parent.Controls)
            {
                Point controlLocation = control.PointToScreen(Point.Empty);

                if (location.X >= controlLocation.X && location.X <= (controlLocation.X + control.Width) &&
                    location.Y >= controlLocation.Y && location.Y <= (controlLocation.Y + control.Height) &&
                    control.GetType() == T)
                {
                    return control;
                }
            }

            return null;
        }
        #endregion
    }
}
