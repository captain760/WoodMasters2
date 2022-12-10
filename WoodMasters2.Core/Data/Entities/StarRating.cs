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
        public int Id { get; set; }

        public int Rate { get; set; }
        [ForeignKey(nameof(MasterPiece))]
        public int MasterPieceId { get; set; }       
        public virtual MasterPiece MasterPiece { get; set; } = null!;
    }
}
