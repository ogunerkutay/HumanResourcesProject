using BusinessLayer.Abstract;
using BusinessLayer.Models.DTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLayer.Services.DepartmentService;
using System.Linq;
using BusinessLayer.Models.VMs;
using BusinessLayer.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace BoostHumanResourcesProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAppUserService appUserService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IDepartmentService departmentService;

        public UserController(ILogger<UserController> logger, IAppUserService appUserService, IWebHostEnvironment hostingEnvironment, IDepartmentService departmentService)
        {
            _logger = logger;
            this.appUserService = appUserService;
            this.hostingEnvironment = hostingEnvironment;
            this.departmentService = departmentService;
        }

        public async Task<IActionResult> PersonList()
        {

            List<AppUserVM> appUserVMs = await appUserService.GetAllUsers();
            return View(appUserVMs);
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            List<GetDepartmentsVM> departmentValue = (from x in await departmentService.GetAllDepartments()
                                                      select new GetDepartmentsVM
                                                      {
                                                          DepartmentName = x.DepartmentName,
                                                          DepartmentID = x.DepartmentID
                                                      }).ToList();
            AppUserandDepartments appUserandDepartments = new AppUserandDepartments();
            AppUserUpdateDTO appUserUpdateDTO = new AppUserUpdateDTO();
            appUserandDepartments.appUserUpdateDTO = appUserUpdateDTO;
            appUserandDepartments.departmentsList = departmentValue;
            return View(appUserandDepartments);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AppUserandDepartments user)
        {
            //AppUserUpdateDTO appUserUpdateDTO = user.appUserUpdateDTO;
            //AppUserUpdateDTOValidator validationRules = new AppUserUpdateDTOValidator();
            //ValidationResult validationResult = validationRules.Validate(appUserUpdateDTO);
            if (ModelState.IsValid)
            {



                await appUserService.Create(user.appUserUpdateDTO);

                return RedirectToAction("Update","User",user);
            }
            //else
            //{
            //    foreach (var item in validationResult.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            return View(user);

        }
        public async Task<IActionResult> UserDetails(int id)
        {

            AppUserDetailsVM appUserDetailsVM = await appUserService.GetById(id);
            return View(appUserDetailsVM);
        }

        public IActionResult StatusChange()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateDTO appUserUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                AppUserUpdateDTO user = await appUserService.GetByIdDTO(appUserUpdateDTO.Id);


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
                            if (System.IO.File.Exists(Path.Combine(userFolder, user.ImagePath)))
                            {
                                System.IO.File.Delete(Path.Combine(userFolder, user.ImagePath));
                            }
                        }

                        uniqueFileName = Path.Combine(appUserUpdateDTO.file.FileName);
                        string filePath = Path.Combine(userFolder, uniqueFileName);

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
