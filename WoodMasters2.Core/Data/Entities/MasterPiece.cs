using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoodMasters2.Core.Data.Entities
{
    public class MasterPiece
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(0.1, 1000.0)]
        public double Width { get; set; }
        [Required]
        [Range(0.1, 1000.0)]
        public double Length { get; set; }
        [Required]
        [Range(0.1, 1000.0)]
        public double Depth { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(256, MinimumLength = 5)]
        public string ImageURL { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.01", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 10000)]
        public int Quantity { get; set; }

        public int RateCount
        {
            get { return ratings.Count; }
        }

        public int RateTotal
        {
            get { return ratings.Sum(m=>m.Rate); }
        }

        public virtual ICollection<StarRating> ratings { get; set; } = new List<StarRating>();

        [Required]
        [ForeignKey(nameof(Master))]
        public string MasterId { get; set; } = null!;
        [Required]
        public virtual Master Master { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Wood))]
        public int WoodId { get; set; }
        public virtual Wood Wood { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;


        
    }
}
