using BusinessLayer.Models.DTOs;
using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez").EmailAddress().WithMessage("Geçerli mail adresi yazınız").MinimumLength(2).WithMessage("Email 2 harften küçük olamaz").MaximumLength(20).WithMessage("Email 20 karakterden fazla olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez").MinimumLength(2).WithMessage("Şifre 2 harften küçük olamaz").MaximumLength(20).WithMessage("Şifre 20 karakterden fazla olamaz");

        }
    }
}
