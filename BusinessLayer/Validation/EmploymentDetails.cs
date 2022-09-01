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
    public class EmploymentDetails : AbstractValidator<EmploymentDetails>
    {
        public EmploymentDetails()
        {
           
        }
    }
}
