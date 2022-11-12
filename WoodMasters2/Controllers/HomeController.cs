using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WoodMasters2.Models;

namespace WoodMasters2.Controllers
{
    /// <summary>
    /// Home controller for Logged-Out users
    /// </summary>
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// _logger controller
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
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
            return View();
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}