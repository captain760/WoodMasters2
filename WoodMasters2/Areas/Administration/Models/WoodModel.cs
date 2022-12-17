using System.ComponentModel.DataAnnotations;

namespace WoodMasters2.Areas.Administration.Models
{
    /// <summary>
    /// Wood adding model
    /// </summary>
    public class WoodModel
    {
        /// <summary>
        /// Id of the Wood
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Type of the Wood
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Type { get; set; } = null!;
    }
}
