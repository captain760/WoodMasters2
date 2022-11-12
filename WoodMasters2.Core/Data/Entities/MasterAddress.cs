using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoodMasters2.Core.Data.Entities
{
    public class MasterAddress
    {
        [Required]
        [ForeignKey(nameof(Master))]
        public string MasterId { get; set; } = null!;
        public virtual Master Master { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;
    }
}
