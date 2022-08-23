using Microsoft.AspNetCore.Mvc;

namespace BoostHumanResourcesProject.Controllers
{
    public class UserController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
