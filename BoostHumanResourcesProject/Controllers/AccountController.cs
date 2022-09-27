using BusinessLayer.Models.DTOs;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoostHumanResourcesProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager; //cookie olayları yöneticek

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {

                        if (await userManager.IsInRoleAsync(user, "Yönetici"))
                        {
                            return RedirectToAction("Manager", "Dashboard", new { @id = user.Id });
                        }
                        else if (await userManager.IsInRoleAsync(user, "Personel"))
                        {
                            return RedirectToAction("Personel", "Dashboard", new { @id = user.Id });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Girilen Kullanıcı Adı Veya Parola Hatalı ");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı ile hesap oluşturulmamış ");
                    return View(model);
                }

            }

            return View(model);

        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
