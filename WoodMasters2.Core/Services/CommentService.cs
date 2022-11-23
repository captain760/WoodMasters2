using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Models;

namespace WoodMasters2.Core.Services
{
    public class CommentService: ICommentService
    {
        private readonly WMDbContext context;

        public CommentService(WMDbContext _context)
        {
            context = _context;
        }

        public async Task<CommentViewModel> GetAllCommentsAsync(int masterPieceId)
        {
            MasterPiece masterPiece = await context.MasterPieces.FindAsync(masterPieceId);
            if (masterPiece==null)
            {
                throw new ArgumentException("MasterPiece Id nit Found!");
            }
            var comments = context.Comments.Where(m => m.MasterPieceId == masterPieceId).ToList();
            var model = new CommentViewModel
            {
                MasterPiece = masterPiece,
                Comments = comments
            };

            return model;
        }
    }
}
