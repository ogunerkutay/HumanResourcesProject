using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository appUserRepository;

        public AppUserService(IAppUserRepository _appUserRepository)
        {
            appUserRepository = _appUserRepository;
        }

        public void Add(AppUser entity)
        {
            appUserRepository.Create(entity);
        }

        public void Delete(AppUser entity)
        {
            appUserRepository.Delete(entity);
        }

        public List<AppUser> GetAll()
        {
            return appUserRepository.GetAll();
        }

        public AppUser GetById(int id)
        {
            return appUserRepository.GetById(id);
        }

        public List<AppUser> GetListById(int id)
        {
            //return appUserRepository.GetListFilter(x => x.Id == id);
            throw new NotImplementedException();
        }

        public void Update(AppUser entity)
        {
            appUserRepository.Update(entity);
        }
    }
}
