using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessCore.Models;
using GuiTest.Models;

namespace GuiTest.Board
{
    public class ChessBoardTile : Panel, IChessboardTile
    {
        private FileCoordinate _file;
        private RankCoordinate _rank;
        public FileCoordinate File { get { return this._file; } set { this._file = value; this.SetBackColor(); } }
        public RankCoordinate Rank { get { return this._rank; }
            set { this._rank = value;  this.SetBackColor(); } }

        private void SetBackColor()
        {
            base.BackColor = ((int)this._file + (int)this._rank) % 2 == 0 ? Color.Red : Color.White;
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {

            }
        }
    }
}
