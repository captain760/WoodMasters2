using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Data.Enums;

namespace WoodMasters2.Core.Models
{
    public class AllMasterPiecesQueryModel
    {
        public const int CraftsPerPage = 3;
        public string? Category { get; init; }

        [Display(Name = "Search by Keyword")]
        public string? SearchKey { get; init; }
        [Display(Name = "Sorting by:")]
        public MasterPieceSorting Sorting { get; init; }
        public int CurrentPage { get; init; } = 1;
        public int TotalCrafts { get; set; }
        public IEnumerable<string> Categories { get; set; } = new List<string>();
        public IEnumerable<MasterPieceViewModel> Crafts { get; set; } = new List<MasterPieceViewModel>();
    }
}
