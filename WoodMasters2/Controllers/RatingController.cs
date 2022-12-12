using Microsoft.AspNetCore.Mvc;
using WoodMasters2.Core.Constants;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Controllers
{
    /// <summary>
    /// Controller for the rating of the MasterPieces
    /// </summary>
    public class RatingController : BaseController
    {
        private readonly IRatingService ratingService;
        /// <summary>
        /// Injecting RatingService
        /// </summary>
        /// <param name="_ratingService"></param>
        public RatingController(IRatingService _ratingService)
        {
            ratingService = _ratingService;
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
            ratingService.PostRatingAsync(rating, mid);
            TempData[MessageConstant.SuccessMessage] = "Thanks for your rating!";
            return Json("You rated this " + rating.ToString() + " star(s)");
        }
    }
}
