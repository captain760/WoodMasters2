using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Models;

namespace WoodMasters2.Controllers
{/// <summary>
/// MasterPiece controller
/// </summary>
    [Authorize]
    public class MasterPieceController : BaseController
    {
        private readonly IMasterPieceService masterPieceService;
        /// <summary>
        /// Injecting MasterPieceService
        /// </summary>
        /// <param name="_masterPieceService"></param>
        public MasterPieceController(IMasterPieceService _masterPieceService)
        {
            masterPieceService = _masterPieceService;
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
                Woods = await masterPieceService.GetWoodsAsync(),
                Suppliers = await masterPieceService.GetSuppliersAsync()
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
            await masterPieceService.AddMasterPieceAsync(model, userId);

            return RedirectToAction(nameof(All));

        }

        //public async Task<IActionResult> AddToCollection(int movieId)
        //{

        //    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        //    await movieService.AddMovieToCollectionAsync(movieId, userId);


        //    return RedirectToAction(nameof(All));
        //}

        //public async Task<IActionResult> Watched()
        //{
        //    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        //    var model = await movieService.GetWatchedAsync(userId);

        //    return View("Mine", model);
        //}

        //public async Task<IActionResult> RemoveFromCollection(int movieId)
        //{
        //    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        //    await movieService.RemoveMovieFromCollectionAsync(movieId, userId);

        //    return RedirectToAction(nameof(Watched));
        //}

    }
}
