using System.ComponentModel.DataAnnotations;

namespace WoodMasters2.Core.Data.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(56)]
        public string Name { get; set; } = null!;
        public virtual List<Address> Addresses { get; set; } = new List<Address>();
    }
}
