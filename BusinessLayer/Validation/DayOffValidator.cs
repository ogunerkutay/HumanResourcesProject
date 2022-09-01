using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class DayOffValidator:AbstractValidator<DayOff>
    {
        public DayOffValidator()
        {
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Başlangıç tarihi boş geçilemez");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Bitiş tarihi boş geçilemez");
            RuleFor(x => x.ReturnDate).NotEmpty().WithMessage("Dönüş tarihi boş geçilemez");
            RuleFor(x => x.DepartmentApproval).NotEmpty().WithMessage("Departman onayı geçilemez");
            RuleFor(x => x.ManagerApproval).NotEmpty().WithMessage("Yönetici onayı geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
            RuleFor(x => x.Description).MaximumLength(150).WithMessage("150 karakteri açmayınız");
            
        }
    }
}
