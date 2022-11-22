using Microsoft.AspNetCore.Mvc;

namespace WoodMasters2.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
