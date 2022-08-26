using BusinessLayer.Abstract;
using BusinessLayer.Models.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BoostHumanResourcesProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAppUserService appUserService;
        private readonly IWebHostEnvironment hostingEnvironment;

        public UserController(ILogger<UserController> logger, IAppUserService appUserService, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            this.appUserService = appUserService;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            appUserService.GetById(1);
            return View();
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(AppUserUpdateDTO appUserUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser user = appUserService.GetById(appUserUpdateDTO.Id);


                if (user != null)
                {

                    user.FirstName = appUserUpdateDTO.FirstName;
                    user.LastName = appUserUpdateDTO.LastName;
                    user.Email = appUserUpdateDTO.Email;
                    user.TCNO = appUserUpdateDTO.TCNO;
                    user.BirthDate = appUserUpdateDTO.BirthDate;
                    user.Address = appUserUpdateDTO.Address;
                    user.Status = appUserUpdateDTO.Status;
                    user.Title = appUserUpdateDTO.Title;
                    user.GrossSalary = appUserUpdateDTO.GrossSalary;
                     


        string uniqueFileName = String.Empty;  //to contain the filename
                    if (appUserUpdateDTO.file != null)  //handle iformfile
                        {

                            string projectRootPath = hostingEnvironment.WebRootPath;
                            string uploadsFolder = Path.Combine(projectRootPath, "images");
                            string userFolder = Path.Combine(uploadsFolder, user.Id.ToString());
                            if (!Directory.Exists(userFolder))
                            {
                                Directory.CreateDirectory(userFolder);
                            }
                            else
                            {
                                if (System.IO.File.Exists(Path.Combine(userFolder,user.ImagePath)))
                                {
                                    System.IO.File.Delete(Path.Combine(userFolder, user.ImagePath));
                                }
                            }
                    
                            uniqueFileName = Path.Combine(appUserUpdateDTO.file.FileName);
                            string filePath = Path.Combine(userFolder,uniqueFileName);
                    
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                    appUserUpdateDTO.file.CopyTo(fileStream);
                            }
                        }

                    user.ImagePath = uniqueFileName;
                    HttpContext.Session.SetString("image", user.ImagePath);
                    appUserService.Update(user);
                    }
                else
                {
                    ModelState.AddModelError("User Operations", "User not found");
                }
                return View(user);
            }
            else
            {
                return View(appUserUpdateDTO);
            }


            
        }
    }
}
