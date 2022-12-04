using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using System.Web;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Models;

namespace WoodMasters2.Controllers
{/// <summary>
/// MasterPiece controller
/// </summary>
    [Authorize]
    public class MasterPieceController : BaseController
    {
        private readonly IMasterPieceService masterPieceService;
        
        private readonly WMDbContext context;

        /// <summary>
        /// Injecting MasterPieceService and context
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="_masterPieceService"></param>
        public MasterPieceController(WMDbContext _context, IMasterPieceService _masterPieceService)
        {
            masterPieceService = _masterPieceService;
            context = _context;
        }
        /// <summary>
        /// showing all MasterPieces
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await masterPieceService.GetAllMasterPiecesAsync();

            return View(model);
        }
        /// <summary>
        /// Add MasterPiece control on GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddMasterPieceViewModel()
            {
                Categories = await masterPieceService.GetCategoriesAsync(),
                Woods = await masterPieceService.GetWoodsAsync()                
            };


            return View(model);
        }
        /// <summary>
        /// Add MasterPiece on POST
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpPost]
        public async Task<IActionResult> Add(AddMasterPieceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await masterPieceService.AddMasterPieceAsync(model, userId!);

            return RedirectToAction(nameof(All));

        }
        /// <summary>
        /// Add to Favorites List
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int masterPieceId)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await masterPieceService.AddMasterPieceToFavoritesAsync(masterPieceId, userId!);


            return RedirectToAction(nameof(All));
        }
        /// <summary>
        /// Get the list of Favorites
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await masterPieceService.GetFavoritesAsync(userId!);

            return View(model);
        }
        /// <summary>
        /// Get the list of Owned MasterPieces
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await masterPieceService.GetMineAsync(userId!);

            return View("Mine",model);
        }

        /// <summary>
        /// Remove a MasterPiece from Favorites list
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Remove(int masterPieceId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await masterPieceService.RemoveMasterPieceFromFavoritesAsync(masterPieceId, userId!);

            return RedirectToAction(nameof(Favorites));
        }

        /// <summary>
        /// Deleteing MasterPiece from Master's collection
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int masterPieceId)
        {
            //var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await masterPieceService.DeleteAsync(masterPieceId);

            return RedirectToAction(nameof(Mine));
        }/// <summary>
        /// Get for Editing a MasterPiece
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await masterPieceService.GetEditMasterPieceAsync(id);
            return View(model);
        }
        /// <summary>
        /// Post for Editing a MasterPiece
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EditMasterPieceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await masterPieceService.EditMasterPieceAsync(model);

            return RedirectToAction(nameof(Mine));
        }
        /// <summary>
        /// PostRating method
        /// </summary>
        /// <param name="rating"></param>
        /// <param name="mid"></param>
        /// <returns></returns>
        [HttpPost]
       public JsonResult PostRating(int rating, int mid)
       {
           //save data into the database
 
           StarRating rt = new StarRating();
          
           rt.Rate = rating;
           
           rt.MasterPieceId = mid;
 
           //save into the database
           context.Ratings.Add(rt);
           context.SaveChanges();
  
           return Json("You rated this " + rating.ToString() + " star(s)");
       }
        
    }
}
