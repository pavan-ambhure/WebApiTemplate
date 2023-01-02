using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Contracts.Models;
using WebApiTemplate.Contracts.Models.DTOs;

namespace WebApiTemplate.Domain.Mapper
{
    public class DomainMapper :Profile
    {
        public DomainMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
