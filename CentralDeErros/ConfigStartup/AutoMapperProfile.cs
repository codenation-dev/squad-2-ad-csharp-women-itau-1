using System;
using AutoMapper;
using CentralDeErros.DTO;
using CentralDeErros.Models;

namespace CentralDeErros.ConfigStartup
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();

        }
    }
}
