using BoostHumanResourcesProject;
using BusinessLayer.Abstract;
using BusinessLayer.AutoMapper;
using BusinessLayer.Models.DTOs;
using BusinessLayer.Models.VMs;
using BusinessLayer.Services.AppUserService;
using BusinessLayer.Services.DayOffService;
using BusinessLayer.Services.DepartmentService;
using BusinessLayer.Services.EmploymentDetailsService;
using BusinessLayer.Validation;
using DataAccessLayer.IRepositories;
using DataAccessLayer;
using EntityLayer.Entities;

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using BusinessLayer.EmailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace BoostHumanResourcesProject
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));
            services.AddMvc();


            //DbContext
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(_configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));

            //Identity
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            //Role
            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, UserClaimsPrincipalFactory<AppUser, AppRole>>();


            //services.Configure<IdentityOptions>(options =>
            //{
            //    //password
            //    options.Password.RequireDigit = true; //say?sal de?er
            //    options.Password.RequireLowercase = true; //k???k harf
            //    options.Password.RequireUppercase = true; //b?y?k harf
            //    options.Password.RequiredLength = 6; //min 6 karakter
            //    options.Password.RequireNonAlphanumeric = true; // karakter i?areti

            //    //lockput
            //    options.Lockout.MaxFailedAccessAttempts = 5; // 5 kere yanl?? parola
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // 5 dk sonra tekrar deneyebilir
            //    options.Lockout.AllowedForNewUsers = true; //lockout aktif olmas? i?in

            //    options.User.RequireUniqueEmail = true; // email uniq olur
            //    options.SignIn.RequireConfirmedEmail = false; //onay maili i?in gerekli 

            //    options.SignIn.RequireConfirmedPhoneNumber = false; //verdi?i tel no i?in onay 
            //});
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/account/login"; //cookie s?resi bitti?inde y?nlendir
            //    options.LogoutPath = "/account/logout"; //kullan?c? ??k?? yap?nca taray?c?dan silinir
            //    options.SlidingExpiration = true; // varsay?lan cookie s?resi 20 dk her istek att???nda s?f?rlan?r ve tekrar 20 dk verir
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //});

            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //    config.Filters.Add(new AuthorizeFilter(policy)); // proje genelinde authorize i?lemi i?in zorunlu k?lar
            //});

            //services.AddFluentValidationAutoValidation();
            //services.AddFluentValidationClientsideAdapters();
            //services.AddValidatorsFromAssemblyContaining<Startup>();
            services.AddControllersWithViews().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
            services.AddScoped<IValidator<AppUserandDepartments>, AppUserandDepartmentsValidators>();
            services.AddScoped<IValidator<AppUserUpdateDTO>, AppUserUpdateDTOValidator>();
            services.AddScoped<IValidator<LoginDTO>, LoginValidator>();
            //fluent validation kulland???m?z i?in eklendi

            //Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDayOffRepository, DayOffRepository>();
            services.AddTransient<IEmploymentDetailsRepository, EmploymentDetailsRepository>();


            //Services
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IEmploymentDetailsService, EmploymentDetailsService>();
            services.AddScoped<IDayOffService, DayOffService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            //ctor da yazd?klar?m?z? buraya parametre olarak verdik.AppSetting Json taraf?ndaki bilgileri de al?p EmailSender_ tarf?na mail port setting bilgilerini paslar.
            services.AddScoped<IEmailSender, EmailSender_>(x=> new EmailSender_ (
                _configuration["EmailSender:Host"],
                _configuration.GetValue<int>("EmailSender:Port"),
                _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                _configuration["EmailSender:UserName"],
                _configuration["EmailSender:Password"]

                ));


            //AutoMapper
            services.AddAutoMapper(typeof(Mapping));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                   name: "areaRoute1",
                   pattern: "{area:exists}/{controller}/{action}/{name?}"
                 );

                endpoints.MapControllerRoute(
                   name: "areaRoute2",
                   pattern: "{area:exists}/{controller}/{action}/{id?}"
                 );

                endpoints.MapControllerRoute(
                   name: "areaRoute",
                   pattern: "{area:exists}/{controller}/{action}"
                 );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}");

            });


        }
    }
}
