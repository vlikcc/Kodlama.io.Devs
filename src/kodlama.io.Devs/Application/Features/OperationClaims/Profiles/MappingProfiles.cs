using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Dtos;
using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim ,CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim,CreateOperationClaimCommand>().ReverseMap();
        }
    }
}
