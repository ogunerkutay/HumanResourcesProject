using Microsoft.AspNetCore.Mvc;

namespace BoostHumanResourcesProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            string asd = "Azure'da Git yapısını kullanıyoruz çok süperiz.";
            return View();
        }
    }
}
