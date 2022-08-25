using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.DTOs
{
    public class AppUserUpdateDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TCNO { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public double GrossSalary { get; set; }
        public IFormFile file { get; set; }


        
    }
}
