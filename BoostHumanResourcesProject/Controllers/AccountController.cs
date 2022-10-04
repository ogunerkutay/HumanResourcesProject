using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Email;
using BusinessLayer.Models.DTOs;
using BusinessLayer.Models.VMs;
using BusinessLayer.Services.AppUserService;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoostHumanResourcesProject.Areas.Personel.Controllers
{
    //[Authorize(Roles = "Personel")]
    public class AccountController : Controller
    {
        private readonly IAppUserService appUserService;
        private readonly UserManager<AppUser> userManager;


        public AccountController(IAppUserService appUserService, UserManager<AppUser> userManager)
        {
            this.appUserService = appUserService;
            this.userManager = userManager;
        }
        //

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (await appUserService.CheckRole(User.Identity.Name, "Yonetici"))
                {
                    //return RedirectToAction("Index", nameof(Areas.Manager.Controllers.DashboardController), new { @name = User.Identity.Name });

                    return RedirectToAction("Index", "Dashboard", new { area = "Manager", @name = User.Identity.Name });
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { @name = User.Identity.Name });
                }
            }
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> LogIn(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await appUserService.LogIn(model);

                HttpContext.Session.SetString("Name", user.FirstName + " " + user.LastName);
                HttpContext.Session.SetString("Image", user.ImagePath);


                if (user != null) return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return View();
            }
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var urlForForgotPassword = Url.Action("ResetPassword", "Account", new {
                userId = user.Id, token=code});
                EmailHelper emailHelper = new EmailHelper();
                string message = $"Şifreniz: {user.FirstName}123Aa! Lütfen unutmayın, değiştirmeyi de ihmal etmeyin!!!";
                bool emailResponse = emailHelper.SendEmail(user.Email, message);
                return emailResponse;
            }
            return View();
        }


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDTO model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByEmailAsync(model.Email);

        //        if (user != null)
        //        {
        //            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

        //            if (result.Succeeded)
        //            {


        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Girilen Kullanıcı Adı Veya Parola Hatalı ");
        //                return View(model);
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Bu kullanıcı adı ile hesap oluşturulmamış ");
        //            return View(model);
        //        }

        //    }

        //    return View(model);

        //}

        public async Task<IActionResult> LogOut()
        {
            await appUserService.LogOut();
            return RedirectToAction("Login");
        }
    }
}
