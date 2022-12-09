using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Models.MasterPieces
{
    public class MasterPieceQueryModel
    {
        public int TotalMasterPieces { get; set; }
        public IEnumerable<MasterPieceViewModel> CraftPieces { get; set; } = new List<MasterPieceViewModel>();
    }
}
