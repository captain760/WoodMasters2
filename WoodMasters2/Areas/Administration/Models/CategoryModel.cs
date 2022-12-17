using System.ComponentModel.DataAnnotations;

namespace WoodMasters2.Areas.Administration.Models
{
    /// <summary>
    /// New Category Model
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// Id of the Category
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Name of the Category
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
    }
}
