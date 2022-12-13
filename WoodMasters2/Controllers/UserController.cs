using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WoodMasters2.Core.Constants;
using WoodMasters2.Core.Data.Entities;
using WoodMasters2.Core.Models.User;

namespace WoodMasters2.Controllers
{
    /// <summary>
    /// Controller for the Accounts of the users
    /// </summary>
    public class UserController : BaseController
    {
        private readonly UserManager<Master> userManager;
        private readonly SignInManager<Master> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        /// <summary>
        /// Master's accounts controller
        /// </summary>
        /// <param name="_userManager"></param>
        /// <param name="_signInManager"></param>
        /// <param name="_roleManager"></param>
        public UserController(UserManager<Master> _userManager, SignInManager<Master> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
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
                TempData[MessageConstant.SuccessMessage] = "You're already logged-in!";
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
                Email = model.Email,
                EmailConfirmed = true,
                
            };
            
            var result = await userManager.CreateAsync(user, model.Password);

            await userManager.AddClaimAsync(user, new System.Security.Claims.Claim(ClaimTypeConstants.FirstName, user.FirstName));

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                TempData[MessageConstant.SuccessMessage] = "Welcome! Please Log-in!";
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            TempData[MessageConstant.ErrorMessage] = "Registration failed!";
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
                TempData[MessageConstant.SuccessMessage] = "You're already logged-in!";
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
                TempData[MessageConstant.ErrorMessage] = "Login failed!";
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            //To create Claims on Login(for the pre-configured users only)
            //await userManager.AddClaimAsync(user, new System.Security.Claims.Claim(ClaimTypeConstants.FirstName, user.FirstName));
            if (user != null)
            {

                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    TempData[MessageConstant.SuccessMessage] = $"Welcome Master!!!";
                    return RedirectToAction("All", "MasterPiece");
                }
            }
            ModelState.AddModelError("", "The Login process is invalid! Try again!");
            TempData[MessageConstant.ErrorMessage] = "Login failed!";
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
            TempData[MessageConstant.SuccessMessage] = $"Good bye {UserFirstName} !";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateRoles()
        {
            await roleManager.CreateAsync(new IdentityRole(RoleConstants.Admin));
            await roleManager.CreateAsync(new IdentityRole(RoleConstants.User));
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AddUsersToRoles()
        {
            string emailAdmin = "b_eftimov@yahoo.com";
            string emailUser = "m_eftimov@yahoo.com";
            var admin =await userManager.FindByEmailAsync(emailAdmin);
            var user =await userManager.FindByEmailAsync(emailUser);
            await userManager.AddToRoleAsync(admin, RoleConstants.Admin);
            await userManager.AddToRoleAsync(user, RoleConstants.User);
            return RedirectToAction("Index", "Home");
        }
    }
}
