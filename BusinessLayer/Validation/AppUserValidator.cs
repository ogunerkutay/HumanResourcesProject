using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class AppUserValidator : AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.TCNO).NotEmpty().WithMessage("TC No boş geçilemez"); // tc 11 hane olmalı kısmı yapılcak
            //RuleFor(x => x.Name).NotEmpty().WithMessage("Name required")
            //        .Must(x => x.Length > 10 && x.Length < 15)
            //        .WithMessage("Name should be between 10 and 15 chars");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");

        }
    }
}
