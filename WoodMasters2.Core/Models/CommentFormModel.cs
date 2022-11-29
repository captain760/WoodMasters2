using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Models
{
    public class CommentFormModel
    {
        //[Required]
        //[StringLength(20, MinimumLength = 2)]
        //public string Author { get; set; } = null!;
        [Required]
        public int MasterPieceId { get; set; }
        [Required]
        [StringLength(1500, MinimumLength = 5)]
        public string Content { get; set; } = null!;
    }
}
