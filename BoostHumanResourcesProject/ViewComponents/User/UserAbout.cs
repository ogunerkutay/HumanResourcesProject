using Microsoft.AspNetCore.Mvc;

namespace BoostHumanResourcesProject.ViewComponents.User
{
    public class UserAbout:ViewComponent
    {





        public IViewComponentResult Invoke() //sisteme otantike olan kullanıcı bilgileri
        {
            return View();
        }
    }
}
