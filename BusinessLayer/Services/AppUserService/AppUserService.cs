using BusinessLayer.Abstract;
using BusinessLayer.Models.DTOs;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Task<bool> Any(Expression<Func<AppUser, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Create(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetAllWhere(Expression<Func<AppUser, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetById(int id)
        {
            var user = await appUserRepository.GetFilteredFirstOrDefault(
                selector: x => new AppUser
                {
                    Id = x.Id
                    
                },
                expression: x => x.Id == id && x.Status == true);
            return user;

        }

        public Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<AppUser, TResult>> selector, Expression<Func<AppUser, bool>> expression, Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>> orderBy = null, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<AppUser, TResult>> selector, Expression<Func<AppUser, bool>> expression, Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>> orderBy = null, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetWhere(Expression<Func<AppUser, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void StatusChange(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser entity)
        {
            appUserRepository.Update(entity);
        }

    }
}
