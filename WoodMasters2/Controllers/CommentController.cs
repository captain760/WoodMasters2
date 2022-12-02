using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WoodMasters2.Core.Contracts;

using WoodMasters2.Core.Models;

namespace WoodMasters2.Controllers
{
    /// <summary>
    /// Comments controller
    /// </summary>
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly IMasterPieceService masterPieceService;
        /// <summary>
        /// Injecting MasterPieceService and CommentService
        /// </summary>
        /// <param name="_masterPieceService"></param>
        /// <param name="_commentService"></param>
        public CommentController(IMasterPieceService _masterPieceService,ICommentService _commentService)
        {
            masterPieceService = _masterPieceService;
            commentService = _commentService;            
        }

        /// <summary>
        /// Post method for showing all comments for a MasterPiece
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <returns></returns>
       //[HttpPost]        
        public async Task<IActionResult> AllComments(int masterPieceId)
        {
            var model = await commentService.GetAllCommentsAsync(masterPieceId);
            return View(model);
        }
        /// <summary>
        /// Get method for Add
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        /// <summary>
        /// Post method for Add
        /// </summary>
        /// <param name="model"></param>
        /// <param name="masterPieceId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CommentFormModel model, int masterPieceId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            
            await commentService.AddCommentAsync(model, userId!,masterPieceId);

            return RedirectToAction(nameof(AllComments), new { masterPieceId });
        }
        /// <summary>
        /// Get method for editing a comment
        /// </summary>
        /// <param name="CommentId"></param>       
        /// <returns></returns>
        [HttpGet]
        //[Route("{CommentId:int}")]
        public async Task<IActionResult> Edit(int CommentId)
        {
            var model = await commentService.GetEditCommentAsync(CommentId);
            return View(model);
        }


        /// <summary>
        /// Post method for editing comment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[Route("{model:EditCommentViewModel}")]
        public async Task<IActionResult> Edit(EditCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await commentService.EditCommentAsync(model);
            int masterPieceId = model.MasterPieceId;

            return RedirectToAction(nameof(AllComments), new {masterPieceId });
                        
        }
        
        /// <summary>
        /// Deleting a comment method
        /// </summary>
        /// <param name="commentId"></param>        
        /// <param name="masterPieceId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int commentId, int masterPieceId)
        {
            await commentService.DeleteAsync(commentId, masterPieceId);

            return RedirectToAction(nameof(AllComments), new { masterPieceId });
        }
    }
}
