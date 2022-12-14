    using AutoMapper;
using BusinessLayer.Models.DTOs;
using BusinessLayer.Models.VMs;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, AppUserUpdateDTO>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
            CreateMap<AppUser, AppUserVM>().ReverseMap().ForAllMembers(x => x.UseDestinationValue());
        }
    }
}
