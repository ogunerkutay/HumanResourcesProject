using BoostHumanResourcesProject.Models;
using BusinessLayer.Models.DTOs;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoostHumanResourcesProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        //private UserManager<AppUser> userManager;
        //private SignInManager<AppUser> signInManager; //cookie olayları yöneticek

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var result  = await _userManager.CreateAsync(user,model.Password);

            if (result.Succeeded)
            {

                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var user = await _userManager.FindByNameAsync(model.UserName);
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Bu kullanıcı adı ile hesap oluşturulmamış ");
                return View(model);
            }
            //if (!await _userManager.IsEmailConfirmedAsync(user))
            //{
            //    ModelState.AddModelError("", "Hesabınızı Onaylayın");
            //    return View(model);
            //}

            var result = await _signInManager.PasswordSignInAsync(user,model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            ModelState.AddModelError("", "Girilen Kullanıcı Adı Veya Parola Hatalı ");
            return View(model);

            //if (ModelState.IsValid)
            //{
            //    var user = await _userManager.FindByEmailAsync(model.Email);

            //    if (user != null)
            //    {
            //        var result = await _signInManager.PasswordSignInAsync(user)

            //        if (result.Succeeded)
            //        {

            //            if (await _userManager.IsInRoleAsync(user, "Yönetici"))
            //            {
            //                return RedirectToAction("Manager", "Dashboard", new { @id = user.Id });
            //            }
            //            else if (await _userManager.IsInRoleAsync(user, "Personel"))
            //            {
            //                return RedirectToAction("Personel", "Dashboard", new { @id = user.Id });
            //            }
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("", "Girilen Kullanıcı Adı Veya Parola Hatalı ");
            //            return View(model);
            //        }
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Bu kullanıcı adı ile hesap oluşturulmamış ");
            //        return View(model);
            //    }

            //}

            //return View(model);

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
