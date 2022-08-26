using Microsoft.AspNetCore.Mvc;

namespace BoostHumanResourcesProject.Controllers
{
    public class ManagerController : Controller
    {
        public PartialViewResult ManagerNavbarPartial()
        {
            return PartialView();
        }
    }
}
