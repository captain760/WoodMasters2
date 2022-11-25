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

        //public ActionResult Index()
        //{
        //    return View(commentService.GetAllCommentsAsync(masterPieceId) .Comments.ToList());
        //}

        /// <summary>
        /// Getting AllComments for the MasterPiece
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AllComments(int masterPieceId)
        {
            
            var model = await commentService.GetAllCommentsAsync(masterPieceId);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddComment(int masterPieceId)
        {
            var masterPiece = masterPieceService.GetMasterPieceByIdAsync(masterPieceId);
            var model = new CommentViewModel()
            {
                //MasterPiece = await masterPieceService.GetAllMasterPiecesAsync().Fir,
                //Woods = await masterPieceService.GetWoodsAsync(),
                //Suppliers = await masterPieceService.GetSuppliersAsync()
            };


            return View(model);
        }
        /// <summary>
        /// Add MasterPiece on POST
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //await masterPieceService.AddCommentAsync(model, userId!);

            return RedirectToAction(nameof(AllComments));

        }
        public IActionResult Index(int masterPieceId)
        {
            var masterPiece = masterPieceService.GetMasterPieceByIdAsync(masterPieceId);
            var comments = commentService.GetAllCommentsAsync(masterPieceId)
                .Where(p => p.Comments.IsDeleted == false)
                .Select(p => new CommentViewModel
                {
                    MasterPiece = masterPiece,
                    Comments = comments
                    
                })
            .ToList();
            return View(posts);
        }

        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(PostFormModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };
            this.data.Posts.Add(post);
            this.data.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var post = this.data.Posts.Find(Id);

            return View(new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }
        [HttpPost]
        public IActionResult Edit(int Id, PostFormModel model)
        {
            var post = this.data.Posts.Find(Id);
            post.Title = model.Title;
            post.Content = model.Content;

            this.data.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var post = this.data.Posts.Find(Id);
            post.IsDeleted = true;

            this.data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
