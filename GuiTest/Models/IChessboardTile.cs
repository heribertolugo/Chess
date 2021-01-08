using ChessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiTest.Models
{
    public interface IChessboardTile
    {
        FileCoordinate File { get; set; }
        RankCoordinate Rank { get; set; }
    }
}
