using BusinessLayer.Abstract;
using BusinessLayer.Models.VMs;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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


        [HttpGet]
        [Route("Dashboard/Personel/{name?}")]
        public async Task<IActionResult> Personel(string name)
        {
            AppUserDetailsVM personel = new AppUserDetailsVM();
            personel = await appUserService.GetByName(name);

            return View(personel);
        }

        [HttpGet]
        [Route("Dashboard/Manager/{name?}")]
        public async Task<IActionResult> Manager(string name)
        {
            AppUserDetailsandEmployeesVM appUserDetailsandEmployeesVM = new AppUserDetailsandEmployeesVM();

            appUserDetailsandEmployeesVM.appUserDetailsVM = await appUserService.GetByName(name);

            appUserDetailsandEmployeesVM.employeeList = await appUserService.GetAllBirthDayEmployees();
            

            ViewBag.v1 = appDbContext.AppUsers.Count().ToString();
            ViewBag.v2 = appDbContext.Departments.Count().ToString();


            return View(appUserDetailsandEmployeesVM);
        }
    }
}
