using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public AppUserRepository(AppDbContext _appDbContext) : base(_appDbContext)
        {
            this._appDbContext = _appDbContext;

        }
       


    }
}
