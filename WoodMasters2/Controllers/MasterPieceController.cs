using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using System.Web;
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
            query.TotalCrafts = queryResult.TotalMasterPieces;
            query.Crafts = queryResult.CraftPieces;
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
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await masterPieceService.AddMasterPieceAsync(model, userId!);

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
        
        
    }
}
