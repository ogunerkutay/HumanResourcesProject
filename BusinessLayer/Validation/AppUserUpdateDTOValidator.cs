using BusinessLayer.Models.DTOs;
using FluentValidation;
using System;

namespace BusinessLayer.Validation
{
    public class AppUserUpdateDTOValidator : AbstractValidator<AppUserUpdateDTO>
    {
        public AppUserUpdateDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim boş geçilemez").Matches(@"^[ abcçdefgğhıijklmnoöpqrsştuüvwxyzABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ]+$").WithMessage("Sadece harf girişi yapılmalıdır.").MinimumLength(2).WithMessage("İsim  2 harften küçük olamaz").MaximumLength(20).WithMessage("İsim 20 karakterden fazla olamaz");
            RuleFor(x => x.SecondName).Matches(@"^[ abcçdefgğhıijklmnoöpqrsştuüvwxyzABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ]+$").WithMessage("Sadece harf girişi yapılmalıdır.").MinimumLength(2).WithMessage("İsim  2 harften küçük olamaz").MaximumLength(20).WithMessage("İsim 20 karakterden fazla olamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez").Matches(@"^[ abcçdefgğhıijklmnoöpqrsştuüvwxyzABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ]+$").WithMessage("Sadece harf girişi yapılmalıdır.").MinimumLength(2).WithMessage("İsim  2 harften küçük olamaz").MaximumLength(20).WithMessage("İsim 20 karakterden fazla olamaz");
            RuleFor(x => x.TCNO).NotEmpty().WithMessage("TC No boş geçilemez")
            .Matches(@"^[0-9]*$").WithMessage("Sadece sayı girişi yapılmalıdır.").Length(11).WithMessage("TC No 11 haneli olmalıdır"); // tc 11 hane olmalı kısmı yapılcak ve hepsi rakam olacak

            
            //RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez")
            //.EmailAddress().WithMessage("Geçerli mail adresi yazınız");
            RuleFor(p => p.BirthDate)
            .NotEmpty().WithMessage("Doğum tarihi boş geçilemez")
            .LessThan(p => DateTime.Now.AddYears(-18)).WithMessage("Personeller 18 yaşından küçük olamaz")
            .GreaterThan(p => DateTime.Now.AddYears(-70)).WithMessage("Personeller 70 yaşından büyük olamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş geçilemez");
            //RuleFor(x => x.Status).IsInEnum().WithMessage("Çalışma durumu belirtilmelidir"); 
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan boş geçilemez").Matches(@"^[abcçdefgğhıijklmnoöpqrsştuüvwxyzABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ]+$").WithMessage("Sadece harf girişi yapılmalıdır.").MinimumLength(2).WithMessage("Ünvan  2 harften küçük olamaz").MaximumLength(20).WithMessage("Ünvan 20 karakterden fazla olamaz");

            //RuleFor(x => x.TCNO).NotEmpty().WithMessage("Maaş girişi yapılmalıdır.")
            //   .Matches(@"^\\d + $").WithMessage("Sadece sayı girişi yapılmalıdır.");


            //RuleFor(x => x.file.Length).NotNull().LessThanOrEqualTo(100).WithMessage("Dosya boyutu izin verilenden büyüktür");

            //RuleFor(x => x.file.ContentType).NotEmpty().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
            //.WithMessage("Dosya tipi izin verilenden farklıdır");

            RuleFor(x => x.DepartmentID).NotEmpty().WithMessage("Departman boş geçilemez");


        }

    }
}








