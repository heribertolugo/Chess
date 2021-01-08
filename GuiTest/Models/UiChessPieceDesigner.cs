using ChessCore.Models;
using GuiTest.Board;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GuiTest.Models
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    internal sealed class UiChessPieceDesigner : ControlDesigner
    {
        public override bool CanBeParentedTo(IDesigner parentDesigner)
        {
            return parentDesigner.Component is IChessboardTile && parentDesigner.Component is System.Windows.Forms.Control;
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.Visible | SelectionRules.Moveable;
            }
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            //DataGridViewFooter dataGridViewFooter = (DataGridViewFooter)component;
            //if (dataGridViewFooter == null)
            //    throw new ArgumentException("whats up bro");
            //this.IsDesigner = dataGridViewFooter.IsDesigner;
            //dataGridViewFooter.IsDesigner = true;
        }
         
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            
            base.InitializeNewComponent(defaultValues);
            IChessboardTile childAtPoint = (this.Component as Control).Parent as IChessboardTile; // ((Control)this.Component).FindForm().GetChildAtPoint(new Point(checked(((Control)this.Component).Location.X), checked(((Control)this.Component).Location.Y)));
            ////this.
            IChessboardTile tile = (this.Component as UiChessPiece).Parent as IChessboardTile;
            //MessageBox.Show(v?.Rank.ToString());
            //Type type = typeof(IChessboardTile);
            if (tile != null)
            {
                UiChessPiece uiPiece = this.Component as UiChessPiece;
                BoardCoordinate cords = new BoardCoordinate(tile.Rank, tile.File);
                Dictionary<object, object> pieceArgs = new Dictionary<object, object>();
                ChessPieceColor pieceOriantation = ((int)cords.Rank < 5) ? ChessPieceColor.White : ChessPieceColor.Black;
                //pieceArgs.Add
                //this.InitializeNewComponent(pieceArgs);
                //uiPiece.Piece = null;
                uiPiece.OwningPlayerOrientation = pieceOriantation;
                uiPiece.InitialBoardCoordinate = new BoardCoordinate(tile.Rank, tile.File);
                //uiPiece.DesignerInitialized(cords, pieceOriantation);
                //((IDesignerHost)this.ParentComponent.Site.GetService(typeof(IDesignerHost))).Container.Add(this.Component);
                //if (childAtPoint.Controls.OfType<DataGridViewFooter>().Count<DataGridViewFooter>() > 0)
                //{
                //    this.KillComponent(((Control)this.Component).Name + " Not Allowed! \rOnly one footer per DataGridView!");
                //}
                //else
                //{
                //    if (((Control)this.Component).Parent.GetType() == typeof(DataGridView))
                //        return;
                //    ((Control)this.Component).Parent = childAtPoint;
                //    DataGridViewFooter component = (DataGridViewFooter)this.Component;
                //    DataGridView dgv = (DataGridView)childAtPoint;
                //    component.SetParent(ref dgv);
                //    ((IDesignerHost)this.ParentComponent.Site.GetService(typeof(IDesignerHost))).Container.Add(this.Component);
                //}
            }
            //else
            //    this.KillComponent("Chess Piece can only be added to a ChessTile");
        }

        //public bool IsDesigner
        //{
        //    get
        //    {
        //        return Conversions.ToBoolean(this.ShadowProperties[nameof(IsDesigner)]);
        //    }
        //    set
        //    {
        //        this.ShadowProperties[nameof(IsDesigner)] = (object)true;
        //    }
        //}



        private void KillComponent(string err = "")
        {
            Exception e = new Exception(err);
            if (string.Compare(err, "", false) != 0) 
                this.DisplayError(e);
            ((IDesignerHost)this.ParentComponent.Site.GetService(typeof(IDesignerHost))).DestroyComponent(this.Component);
        }
    }
}
