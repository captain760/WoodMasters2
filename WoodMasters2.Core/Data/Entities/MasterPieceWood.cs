using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoodMasters2.Core.Data.Entities
{
    public class MasterPieceWood
    {
        [Required]
        [ForeignKey(nameof(MasterPiece))]
        public int MasterPieceId { get; set; }
        public virtual MasterPiece MasterPiece { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Wood))]
        public int WoodId { get; set; }
        public virtual Wood Wood { get; set; } = null!;


    }
}
