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
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Author { get; set; }
        [Required]
        [StringLength(1500, MinimumLength = 30)]
        public string Content { get; set; }
    }
}
