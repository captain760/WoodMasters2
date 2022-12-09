using System.ComponentModel.DataAnnotations;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Core.Models.MasterPieces
{
    public class AddMasterPieceViewModel
    {

        /// <summary>
        /// MasterPiece name
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// MasterPiece width
        /// </summary>
        [Required]
        [Range(0.1, 1000.0)]
        public double Width { get; set; }
        /// <summary>
        /// MasterPiece length
        /// </summary>
        [Required]
        [Range(0.1, 1000.0)]
        public double Length { get; set; }
        /// <summary>
        /// MasterPiece thickness
        /// </summary>
        [Required]
        [Range(0.1, 1000.0)]
        public double Depth { get; set; }
        /// <summary>
        /// MasterPiece description
        /// </summary>
        [Required]
        [StringLength(5000, MinimumLength = 2)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// MasterPiece image
        /// </summary>
        [Required]
        [StringLength(256, MinimumLength = 5)]
        public string ImageURL { get; set; } = null!;


        /// <summary>
        /// MasterPiece wood type
        /// </summary>
        [Required]
        public int WoodId { get; set; }

        /// <summary>
        /// MasterPiece craft type
        /// </summary>
        [Required]
        public int CategoryId { get; set; }
        /// <summary>
        /// MasterPiece price
        /// </summary>public string? Category { get; set; }
        [Required]
        [Range(typeof(decimal), "0.01", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
        /// <summary>
        /// MasterPiece quantity available
        /// </summary>
        [Required]
        [Range(1, 10000)]
        public int Quantity { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Wood> Woods { get; set; } = new List<Wood>();


    }
}
