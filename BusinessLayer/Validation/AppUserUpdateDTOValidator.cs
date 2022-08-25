using BusinessLayer.Models.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class AppUserUpdateDTOValidator : AbstractValidator<AppUserUpdateDTO>
    {
        public AppUserUpdateDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.TCNO).NotEmpty().Length(11).WithMessage("TC No boş geçilemez")
            .Matches(@"^\\d + $").WithMessage("Sadece sayı girişi yapılmalıdır."); // tc 11 hane olmalı kısmı yapılcak ve hepsi rakam olacak
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez")
                .EmailAddress().WithMessage("Geçerli mail adresi yazınız");
            RuleFor(p => p.BirthDate)
            .NotEmpty().WithMessage("Doğum tarihi boş geçilemez")
            .LessThan(p => DateTime.Now).WithMessage("Doğum tarihi bugünün tarihinden büyük olamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş geçilemez");
            RuleFor(x => x.Status).IsInEnum().WithMessage("Çalışma durumu belirtilmelidir"); 
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan boş geçilemez");
            RuleFor(x => x.TCNO).NotEmpty().WithMessage("Maaş girişi yapılmalıdır.")
               .Matches(@"^\\d + $").WithMessage("Sadece sayı girişi yapılmalıdır.");

            
            RuleFor(x => x.file.Length).NotNull().LessThanOrEqualTo(100).WithMessage("Dosya boyutu izin verilenden büyüktür");

            RuleFor(x => x.file.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
            .WithMessage("Dosya tipi izin verilenden farklıdır");




        }

    }
}








