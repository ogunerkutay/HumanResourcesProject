using BusinessLayer.Models.DTOs;
using BusinessLayer.Models.VMs;
using BusinessLayer.Services.GenericService;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAppUserService : IGenericService<AppUserUpdateDTO>
    {
        Task SifreOlustur();
        Task<List<AppUser>> GetAllUsersAppUser();
        Task<bool> CheckRole(string email, string role);
        Task<SignInResult> LogIn(LoginDTO model);
        Task LogOut();
        Task<AppUserDetailsVM> GetById(int id);
        Task<AppUserDetailsVM> GetByName(string userName);
        Task<List<AppUserVM>> GetAllBirthDayEmployees();
        Task<AppUserUpdateDTO> GetByIdDTO(int id);
        Task<List<AppUserVM>> GetAllUsers();
        void StatusChange(AppUserUpdateDTO appUser);
    }
}
