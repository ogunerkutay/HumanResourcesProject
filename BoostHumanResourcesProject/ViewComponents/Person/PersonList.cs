using Microsoft.AspNetCore.Mvc;

namespace BoostHumanResourcesProject.ViewComponents
{
    public class PersonList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
