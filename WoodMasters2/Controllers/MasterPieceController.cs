using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using System.Web;
using WoodMasters2.Core.Constants;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Models.MasterPieces;

namespace WoodMasters2.Controllers
{/// <summary>
/// MasterPiece controller
/// </summary>
    [Authorize]
    public class MasterPieceController : BaseController
    {
        private readonly IMasterPieceService masterPieceService;
        
        

        /// <summary>
        /// Injecting MasterPieceService and context
        /// </summary>
        
        /// <param name="_masterPieceService"></param>
        public MasterPieceController(IMasterPieceService _masterPieceService)
        {
            masterPieceService = _masterPieceService;
            
        }



        /// <summary>
        /// AllCrafts method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult All([FromQuery] AllMasterPiecesQueryModel query)
        {
            var queryResult = masterPieceService.AllCrafts(
                query. Category,
                query.SearchKey,
                query.Sorting,
                query.CurrentPage,
                AllMasterPiecesQueryModel.CraftsPerPage);
            query.TotalCrafts = queryResult.Result.TotalMasterPieces;
            query.Crafts = queryResult.Result.CraftPieces;
            var masterPieceCategories = this.masterPieceService.AllCategoriesNames();
            query.Categories = masterPieceCategories;

                return View(query);
        }
            



        /// <summary>
        /// Get method for the last 3 MasterPieces
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await masterPieceService.GetLast3MasterPiecesAsync();
            if (User?.Identity?.IsAuthenticated == false)
            {

                TempData[MessageConstant.SuccessMessage] = "Welcome! Please Log-in!";
                
            }
            return View(model);
        }

        /// <summary>
        /// Get method for the Details of a MasterPiece
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <returns></returns>
        [HttpGet]
        
        public async Task<IActionResult> Details(int masterPieceId)
        {
            var model = await masterPieceService.GetMasterPieceViewByIdAsync(masterPieceId);
            

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
        [HttpPost]
        public async Task<IActionResult> Add(AddMasterPieceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if ((await masterPieceService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }
            if ((await masterPieceService.WoodExists(model.WoodId)) == false)
            {
                ModelState.AddModelError(nameof(model.WoodId), "Wood type does not exist");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await masterPieceService.AddMasterPieceAsync(model, userId!);
            TempData[MessageConstant.SuccessMessage] = "Masterpiece added!";
            return RedirectToAction(nameof(All));

        }
        
        /// <summary>
        /// Add to Favorites List
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AddToFavorites(int masterPieceId)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await masterPieceService.AddMasterPieceToFavoritesAsync(masterPieceId, userId!);
            TempData[MessageConstant.SuccessMessage] = "Masterpiece added to Favorites!";

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
       
        public async Task<IActionResult> Remove(int masterPieceId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await masterPieceService.RemoveMasterPieceFromFavoritesAsync(masterPieceId, userId!);
            TempData[MessageConstant.WarningMessage] = "Masterpiece removed from Favorites!";
            return RedirectToAction(nameof(Favorites));
        }

        /// <summary>
        /// Deleteing MasterPiece from Master's collection
        /// </summary>
        /// <param name="masterPieceId"></param>
        /// <returns></returns>
         
        public async Task<IActionResult> Delete(int masterPieceId)
        {
            await masterPieceService.DeleteAsync(masterPieceId);
            TempData[MessageConstant.ErrorMessage] = "Masterpiece deleted!";
            return RedirectToAction(nameof(All));

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
            TempData[MessageConstant.SuccessMessage] = "Masterpiece edited!";
            return RedirectToAction(nameof(Mine));
        }
        
        
    }
}
