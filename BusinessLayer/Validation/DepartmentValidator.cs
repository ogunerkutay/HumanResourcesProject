using EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class DepartmentValidator:AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("Departman ismi boş geçemezsiniz");
            RuleFor(x => x.DepartmentDescription).NotEmpty().WithMessage("Departman açıklaması boş geçemezsiniz");
            RuleFor(x => x.DepartmentDescription).MaximumLength(150).WithMessage("150 karakteri aşmayınız");
            RuleFor(x => x.DepartmentName).MinimumLength(2).WithMessage("Lütfen 2 karakterden fazla veri girişi yapınız");

        }
    }
}
