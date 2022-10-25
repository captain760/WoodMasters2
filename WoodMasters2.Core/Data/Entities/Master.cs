using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data.Enums;

namespace WoodMasters2.Core.Data.Entities
{
    public class Master: IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string LastName { get; set; } = null!;

        public Experience Experience { get; set; }
        public virtual List<MasterPiece> MasterPieces{ get; set; } = new List<MasterPiece>();
        public virtual List<MasterAddress> MastersAddresses { get; set; } = new List<MasterAddress>();
    }
}
