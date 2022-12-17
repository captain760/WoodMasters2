using Microsoft.AspNetCore.Mvc;
using WoodMasters2.Areas.Administration.Models;
using WoodMasters2.Controllers;
using WoodMasters2.Core.Constants;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Areas.Administration.Controllers
{
    /// <summary>
    /// Admin Controller
    /// </summary>
    [Area("Administration")]
    public class AdminController : BaseController
    {
            private readonly WMDbContext context;
        /// <summary>
        /// Home controller for administration
        /// </summary>
        /// <param name="_context"></param>
            public AdminController(WMDbContext _context)
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
        /// <summary>
        /// Get method to add Category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddCategory()
        {
            var model = new CategoryModel();
            return View(model);
        }
        /// <summary>
        /// Post Method to add Category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCategory(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Category name is invalid!";
                return View();
            }
            if (context.Categories.Any(n => n.Name == model.Name))
            {
                TempData[MessageConstant.WarningMessage] = "Category already exists!";
                return View();
            }
            var newCategory = new Category()
            {
                Name = model.Name
            };
            TempData[MessageConstant.SuccessMessage] = "New category added!";
            context.Categories.Add(newCategory);
            context.SaveChanges();

            return RedirectToAction("Index", "Admin", new {area = "Administration"});
        }
        /// <summary>
        /// Get Method for adding type of Wood
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddWood()
        {
            var model = new WoodModel();
            return View(model);
        }
        /// <summary>
        /// Post method to add wood type
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddWood(WoodModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Wood type is invalid!";
                return View();
            }
            if (context.Woods.Any(n => n.Type == model.Type))
            {
                TempData[MessageConstant.WarningMessage] = "Wood type already exists!";
                return View();
            }
            var newWood = new Wood()
            {
                Type = model.Type
            };
            TempData[MessageConstant.SuccessMessage] = "Wood type added!";
            context.Woods.Add(newWood);
            context.SaveChanges();

            return RedirectToAction("Index", "Admin", new { area = "Administration" });
        }
    }
}
