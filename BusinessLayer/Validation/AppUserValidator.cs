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
            RuleFor(x => x.TCNO).NotEmpty().Length(11).WithMessage("TC No boş geçilemez")
            .Matches(@"^\\d + $").WithMessage("Sadece sayı girişi yapılmalıdır."); ; // tc 11 hane olmalı kısmı yapılcak ve hepsi rakam olacak
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");
           
            
        }
    }
}
