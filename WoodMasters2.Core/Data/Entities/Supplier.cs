using System.ComponentModel.DataAnnotations;

namespace WoodMasters2.Core.Data.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public virtual List<Wood> Woods { get; set; } = new List<Wood>();
    }
}
