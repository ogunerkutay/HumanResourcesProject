using BusinessLayer.Models.DTOs;
using BusinessLayer.Services.GenericService;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUser>
    {
  
        Task<AppUser> GetById(int id);
        void StatusChange(AppUser appUser);
    }
}
