using Microsoft.AspNetCore.Mvc;
using WoodMasters2.Areas.Administration.Models;
using WoodMasters2.Controllers;
using WoodMasters2.Core.Data;

namespace WoodMasters2.Areas.Administration.Controllers
{
    /// <summary>
    /// Admin Controller
    /// </summary>
    [Area("Administration")]
    public class UsersController : BaseController
    {
            private readonly WMDbContext context;
        /// <summary>
        /// Home controller for administration
        /// </summary>
        /// <param name="_context"></param>
            public UsersController(WMDbContext _context)
            {
                context = _context;
            }
        /// <summary>
        /// Admin Index method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
            public IActionResult Index()
        {
            var model = context.Users
                .Select(u=>new UsersModel
                {
                    MasterUserName = u.UserName,
                    MasterFirstName = u.FirstName,
                    MasterLastName = u.LastName,
                    MasterEmail = u.Email,
                    MasterPiecesCount = u.MasterPieces.Count()
                })
                .ToList();
            return View(model);
        }
    }
}
