using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Models;

namespace WoodMasters2.Controllers
{
    /// <summary>
    /// Controller for the Accounts of the users
    /// </summary>
    public class UserController : BaseController
    {
        private readonly UserManager<Master> userManager;
        private readonly SignInManager<Master> signInManager;
        /// <summary>
        /// Master's accounts controller
        /// </summary>
        /// <param name="_userManager"></param>
        /// <param name="_signInManager"></param>
        public UserController(UserManager<Master> _userManager, SignInManager<Master> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }
        /// <summary>
        /// Register Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "MasterPiece");
            }
            var model = new RegisterViewModel();

            return View(model);
        }
        /// <summary>
        /// Register Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Master()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MastersAddresses = new List<MasterAddress>()
                {
                    new MasterAddress()
                    {
                        Address = new Address()
                        {
                            PlaceName = model.PlaceName,
                            Country = new Country()
                            {
                                Name = model.Country
                            }
                        }
                    }
                },
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }
        /// <summary>
        /// Login Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "MasterPiece");
            }
            var model = new LoginViewModel();

            return View(model);
        }
        /// <summary>
        /// Login Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("All", "MasterPiece");
                }
            }
            ModelState.AddModelError("", "The Login process is invalid! Try again!");

            return View(model);
        }
        /// <summary>
        /// LogOut control - redirect to Home/Index
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
