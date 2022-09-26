using Microsoft.AspNetCore.Mvc;

namespace BoostHumanResourcesProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
