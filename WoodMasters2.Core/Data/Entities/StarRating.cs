using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Data.Entities
{
    public class StarRating
    {
        [Key]
        public int RateId { get; set; }

        public int Rate { get; set; }

             
        public int MasterPieceId { get; set; }

        [ForeignKey(nameof(MasterPieceId))]
        public virtual MasterPiece MasterPiece { get; set; } = null!;
    }
}
