using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Login;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User,UserForRegisterDto>().ReverseMap();
            CreateMap<User,CreateUserCommand>().ReverseMap();

            CreateMap<User, LoginUserCommand>().ReverseMap();
            CreateMap<User, UserForLoginDto>().ReverseMap();

            CreateMap<User,UpdatedUserDto>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();

            CreateMap<User, DeleteUserCommand>().ReverseMap();

             
            
        }
    }
}
