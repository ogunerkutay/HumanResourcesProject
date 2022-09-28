using EntityLayer.Entities;
using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.VMs
{
    public class AppUserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
       
    }
}
