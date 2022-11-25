using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Core.Models
{
    public class CommentViewModel
    {
        public MasterPiece MasterPiece { get; set; } = null!;
        public IEnumerable<Comment> Comments { get; set; } = null!;


        //public int Id { get; set; }
        //public string Title { get; set; }
        //public string Content { get; set; }

    }
}
