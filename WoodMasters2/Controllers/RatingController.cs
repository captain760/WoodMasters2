using Microsoft.AspNetCore.Mvc;

namespace WoodMasters2.Controllers
{
    /// <summary>
    /// Rating controller
    /// </summary>
    public partial class RatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
