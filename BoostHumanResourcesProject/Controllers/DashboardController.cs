using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BoostHumanResourcesProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext appDbContext;
        //protected DbSet<T> table;
        public DashboardController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
            //table = _appDbContext.Set<T>();
        }

        public IActionResult Index()
        {
            ViewBag.v1 = appDbContext.AppUsers.Count().ToString();
            ViewBag.v2 = appDbContext.Departments.Count().ToString();
            ViewBag.v3 = appDbContext.DayOffs.Count().ToString();
            return View();
        }
    }
}
