using BusinessLayer.Models.DTOs;
using BusinessLayer.Models.VMs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class AppUserandDepartmentsValidators : AbstractValidator<AppUserandDepartments>
    {
        public AppUserandDepartmentsValidators()
        {
            RuleFor(x => x.appUserUpdateDTO).SetValidator(new AppUserUpdateDTOValidator());
        }
    }
}
