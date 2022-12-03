using Microsoft.EntityFrameworkCore;
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

        public async Task AddCommentAsync(CommentFormModel model, string authorId, int masterPieceId)
        {
            MasterPiece? masterPiece = await context.MasterPieces.FindAsync(model.MasterPieceId);
            if (masterPiece == null)
            {
                throw new ArgumentException("MasterPiece Id not Found!");
            }
            
            var entity = new Comment()
            {
                MasterId = authorId,
                MasterPieceId = model.MasterPieceId,
                Body = model.Content,
                PostingTime = DateTime.Now,
                IsDeleted = false
            };
            await context.Comments.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        

        public async Task DeleteAsync(int commentId, int masterPieceId)
        {
            var commentToDelete = await context.Comments.FirstOrDefaultAsync(f => f.Id == commentId);

            if (commentToDelete != null)
            {
                commentToDelete.IsDeleted = true;

                await context.SaveChangesAsync();

            }
        }

       

        public async Task EditCommentAsync(EditCommentViewModel model)
        {
            Comment? comment = await context.Comments.FindAsync(model.CommentId);
            if (comment != null)
            {
                comment.Body = model.Content;
                comment.PostingTime = DateTime.Now;
            }
                       
            await context.SaveChangesAsync();
        }


        public async Task<CommentViewModel> GetAllCommentsAsync(int masterPieceId)
        {
            var masterPiece = await context.MasterPieces
                .Where(mp => mp.IsDeleted == false && mp.Id == masterPieceId)
                .Include(x => x.Master)                
                .Include(x => x.Category)
                .Include(x => x.Wood)
                .FirstOrDefaultAsync();
                
            if (masterPiece==null)
            {
                throw new ArgumentException("MasterPiece Id not Found!");
            }
            var comments = context.Comments
                .Where(m => m.MasterPieceId == masterPieceId && m.IsDeleted ==false)
                .Include(m=>m.Master)
                .ToList();
            var model = new CommentViewModel
            {
                MasterPiece = masterPiece,
                Comments = comments
            };

            return model;
        }

        public async Task<EditCommentViewModel> GetEditCommentAsync(int CommentId)
        {
            Comment? comment = await context.Comments.FindAsync(CommentId);
            var model = new EditCommentViewModel();
            if (comment!=null)
            {
                
                {
                    model.Content = comment.Body;
                };
            }
            
            return model;
        }

    }
}
