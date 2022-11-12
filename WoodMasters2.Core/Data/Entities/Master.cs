using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WoodMasters2.Core.Data.Enums;

namespace WoodMasters2.Core.Data.Entities
{
    public class Master : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; private set; } = DateTime.Now;


        public Experience Experience { get; set; }

        public virtual List<MasterAddress> MastersAddresses { get; set; } = new List<MasterAddress>();
        public virtual List<MasterPiece> MasterPieces { get; set; } = new List<MasterPiece>();
        /// <summary>
        /// List of favorite MasterPiece's Ids
        /// </summary>

        public List<Favorite> Favorites { get; set; } = new List<Favorite>();

    }
}
