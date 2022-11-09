using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WoodMasters2.Controllers
{
    /// <summary>
    /// Base controller inherited by all other controllers
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
        private string userFirstName;

        public string UserFirstName 
        { get 
            {
                string firstName = string.Empty;
                if (User!=null && User.HasClaim(c=>c.Type=="first_name"))
                {
                    firstName = User.Claims.FirstOrDefault(c => c.Type == "first_name")?.Value ?? firstName;
                }
                return firstName;
            }          
        }
    }
}
