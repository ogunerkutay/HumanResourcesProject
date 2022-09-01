using DataAccessLayer.IRepositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DayOffRepository : GenericRepository<DayOff>, IDayOffRepository
    {
        public DayOffRepository(AppDbContext _appDbContext) : base(_appDbContext)
        {

        }

    }
}
