using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WoodMasters2.Core.Constants;

namespace WoodMasters2.Controllers
{
    /// <summary>
    /// Home controller for Logged-Out users
    /// </summary>
    public class HomeController : BaseController
    {
        
        /// <summary>
        /// Index controller
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "MasterPiece");
            }
            TempData[MessageConstant.WarningMessage] = "Please log-in to enter!";
            return RedirectToAction("Index", "MasterPiece");
        }
        /// <summary>
        /// Privacy controller
        /// </summary>
        /// <returns></returns>

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Errors handling controller
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            TempData[MessageConstant.ErrorMessage] = "Ops, something went wrong!";

            if (statusCode == 400)
            {
                return View("Error400");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }
            return View();
        }
    }
}