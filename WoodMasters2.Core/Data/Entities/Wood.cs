using System.ComponentModel.DataAnnotations;

namespace WoodMasters2.Core.Data.Entities
{
    public class Wood
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; } = null!;

        public virtual List<MasterPiece> MasterPieces { get; set; } = new List<MasterPiece>();


    }
}
