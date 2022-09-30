using BusinessLayer.Abstract;
using BusinessLayer.Models.VMs;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoostHumanResourcesProject.Controllers
{
    [Area("Personel")]
    [Authorize(Roles = "Personel")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IAppUserService appUserService;
        //protected DbSet<T> table;
        public DashboardController(AppDbContext appDbContext, IAppUserService appUserService)
        {
            this.appDbContext = appDbContext;
            this.appUserService = appUserService;
            //table = _appDbContext.Set<T>();
        }
        
        [HttpGet]
        [Route("Personel/Dashboard/Index/{name?}")]
        public async Task<IActionResult> Index(string name)
        {
            AppUserDetailsVM personel = new AppUserDetailsVM();
            personel = await appUserService.GetByName(name);

            return View(personel);
        }

    }
}
