using Microsoft.AspNetCore.Mvc;

namespace BoostHumanResourcesProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
