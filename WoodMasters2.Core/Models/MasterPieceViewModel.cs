namespace WoodMasters2.Core.Models
{
    /// <summary>
    /// MasterPiece Dto model
    /// </summary>
    public class MasterPieceViewModel
    {
        /// <summary>
        /// MasterPiece identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// MasterPiece name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// MasterPiece crafter
        /// </summary>
        public string Master { get; set; } = null!;
        /// <summary>
        /// Master's Email
        /// </summary>
        public string MasterEmail { get; set; } = null!;
        public string? MasterPhone { get; set; }
        /// <summary>
        /// MasterPiece width
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// MasterPiece length
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// MasterPiece thickness
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// MasterPiece description
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// MasterPiece image
        /// </summary>
        public string ImageURL { get; set; } = null!;
        /// <summary>
        /// MasterPiece wood type
        /// </summary>
        public string? Wood { get; set; }
        /// <summary>
        /// MasterPiece craft type
        /// </summary>
        public string? Category { get; set; }
        /// <summary>
        /// MasterPiece price
        /// </summary>public string? Category { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// MasterPiece quantity available
        /// </summary>
        public int Quantity { get; set; }

        public int RateCount { get; set; }
        public int RateTotal { get; set; }
        


    }
}
