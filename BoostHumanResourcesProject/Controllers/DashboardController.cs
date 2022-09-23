using BusinessLayer.Abstract;
using BusinessLayer.Models.VMs;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BoostHumanResourcesProject.Controllers
{
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

        public async Task<IActionResult> Index()
        {
            AppUserDetailsVM appUserDetailsVM = await appUserService.GetById(8);

            ViewBag.v1 = appDbContext.AppUsers.Count().ToString();
            ViewBag.v2 = appDbContext.Departments.Count().ToString();


            return View(appUserDetailsVM);
        }
    }
}
