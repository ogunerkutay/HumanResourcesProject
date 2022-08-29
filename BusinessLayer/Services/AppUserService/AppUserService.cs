using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.DTOs;
using BusinessLayer.Models.VMs;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;

        public AppUserService(IAppUserRepository _appUserRepository, IMapper mapper)
        {
            this.appUserRepository = _appUserRepository;
            this.mapper = mapper;
            //
        }

        public Task<bool> Any(Expression<Func<AppUserUpdateDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task Create(AppUserUpdateDTO user)
        {
            var createUser = mapper.Map<AppUser>(user);
            createUser.Status = true;
            await appUserRepository.Create(createUser);
           
        }

        public Task Delete(AppUserUpdateDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUserUpdateDTO>> GetAllWhere(Expression<Func<AppUserUpdateDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }
        public async Task<List<AppUserVM>> GetAllUsers()
        {
            var users = await appUserRepository.GetFilteredList(
                selector: x => new AppUserVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ImagePath = x.ImagePath,
                    Title = x.Title,
                    Department = x.Department

                },
                expression: x => x.FirstName != null,
                orderBy: x => x.OrderBy(x => x.FirstName),
                includes: x => x.Include(x => x.Department)
                );
               
            return users;
        }

        public async Task<AppUserDetailsVM> GetById(int id)
        {
            var user = await appUserRepository.GetFilteredFirstOrDefault(
                selector: x => new AppUserDetailsVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Department = x.Department,
                    TCNO = x.TCNO,
                    BirthDate = x.BirthDate,
                    Address = x.Address,
                    Title = x.Title
                    
                },
                expression: x => x.Id == id && x.Status == true);
            return user;
            //
        }
        public async Task<AppUserUpdateDTO> GetByIdDTO(int id)
        {
            var user = await appUserRepository.GetFilteredFirstOrDefault(
                selector: x => new AppUserUpdateDTO
                {
                    Id = x.Id
                },
                expression: x => x.Id == id && x.Status == true);
            return user;
            //
        }

        public Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<AppUserUpdateDTO, TResult>> selector, Expression<Func<AppUserUpdateDTO, bool>> expression, Func<IQueryable<AppUserUpdateDTO>, IOrderedQueryable<AppUserUpdateDTO>> orderBy = null, Func<IQueryable<AppUserUpdateDTO>, IIncludableQueryable<AppUserUpdateDTO, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<AppUserUpdateDTO, TResult>> selector, Expression<Func<AppUserUpdateDTO, bool>> expression, Func<IQueryable<AppUserUpdateDTO>, IOrderedQueryable<AppUserUpdateDTO>> orderBy = null, Func<IQueryable<AppUserUpdateDTO>, IIncludableQueryable<AppUserUpdateDTO, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<AppUserUpdateDTO> GetWhere(Expression<Func<AppUserUpdateDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void StatusChange(AppUserUpdateDTO appUser)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUserUpdateDTO user)
        {
            var updateUser = mapper.Map<AppUser>(user);
            updateUser.Status = !updateUser.Status;
            appUserRepository.Update(updateUser);
        }
        //public void StatusChange(AppUser appUser)
        //{
        //    appUser.Status = !appUser.Status;
        //    _appDbContext.Entry<AppUser>(appUser).State = EntityState.Modified;
        //    _appDbContext.SaveChanges();
        //}

        //public void StatusCreate(AppUser appUser)
        //{
        //    appUser.Status = true;
        //    _appDbContext.Entry<AppUser>(appUser).State = EntityState.Added;
        //    _appDbContext.SaveChanges();
        //}

    }
}
