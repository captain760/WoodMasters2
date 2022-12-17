using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WoodMasters2.Core.Constants;

namespace WoodMasters2.Areas.Administration.Controllers
{
    /// <summary>
    /// Base controller for the Admin area
    /// </summary>
    [Area("Administration")]
    [Route("/Administration/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "Admin")]
    
    public class BaseController : Controller
    {
        /// <summary>
        /// Creating Claim: UserFirstName
        /// </summary>

        public string UserFirstName
        {
            get
            {
                string firstName = string.Empty;
                if (User?.Identity?.IsAuthenticated ?? false && User.HasClaim(c => c.Type == ClaimTypeConstants.FirstName))
                {
                    firstName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypeConstants.FirstName)?.Value ?? firstName;
                }
                return firstName;
            }
        }
        /// <summary>
        /// Attaching UserFirstName always to the ViewBag
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                ViewBag.UserFirstName = UserFirstName;
            }

            base.OnActionExecuted(context);
        }
    }
}
