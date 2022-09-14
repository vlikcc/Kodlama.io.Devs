using Application.Features.SocialMediaProfiles.Commands.Create;
using Application.Features.SocialMediaProfiles.Commands.Delete;
using Application.Features.SocialMediaProfiles.Commands.Update;
using Application.Features.SocialMediaProfiles.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMediaProfile,CreatedSocialMediaProfileDto>().ReverseMap();
            CreateMap<SocialMediaProfile,CreateSocialMediaProfileCommand>().ReverseMap();

            CreateMap<SocialMediaProfile, UpdatedSocialMediaProfileDto>().ReverseMap();
            CreateMap<SocialMediaProfile, UpdateSocialMediaProfileCommand>().ReverseMap();

            CreateMap<SocialMediaProfile, DeletedSocialMediaProfileDto>().ReverseMap();
            CreateMap<SocialMediaProfile, DeleteSocialMediaProfileCommand>().ReverseMap();


        }
    }
}
