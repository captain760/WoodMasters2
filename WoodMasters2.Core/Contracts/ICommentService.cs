using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Models.Comments;

namespace WoodMasters2.Core.Contracts
{
    public interface ICommentService
    {
        Task<CommentViewModel> GetAllCommentsAsync(int masterPieceId);
        Task AddCommentAsync(CommentFormModel model,string authorId, int masterPieceId);
        Task<EditCommentViewModel> GetEditCommentAsync(int id);
        Task EditCommentAsync(EditCommentViewModel model);
        Task DeleteAsync(int commentId, int masterPieceId);

    }
}
