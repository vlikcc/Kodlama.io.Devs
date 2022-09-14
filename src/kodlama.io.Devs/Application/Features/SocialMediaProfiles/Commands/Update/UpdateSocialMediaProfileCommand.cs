using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.SocialMediaProfiles.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaProfiles.Commands.Update
{
    public class UpdateSocialMediaProfileCommand:IRequest<UpdatedSocialMediaProfileDto>
    {
        public int Id { get; set; }
        public string SocialMediaUserName { get; set; }
        public string ProfileUrl { get; set; }

        public class UpdateSocialMediaProfileCommandHandler:IRequestHandler<UpdateSocialMediaProfileCommand,UpdatedSocialMediaProfileDto>
        {
            private readonly ISocialMediaProfileRepository _socialMediaProfileRepository;
            private readonly IMapper _mapper;

            public UpdateSocialMediaProfileCommandHandler(ISocialMediaProfileRepository socialMediaProfileRepository, IMapper mapper)
            {
                _socialMediaProfileRepository = socialMediaProfileRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSocialMediaProfileDto> Handle(UpdateSocialMediaProfileCommand request, CancellationToken cancellationToken)
            {
                SocialMediaProfile? socialMediaProfile = await _socialMediaProfileRepository.GetAsync(s=>s.Id == request.Id);
                socialMediaProfile.SocialMediaUserName = request.SocialMediaUserName;
                socialMediaProfile.ProfileUrl = request.ProfileUrl;
                SocialMediaProfile updatedSocialMediaProfile = await _socialMediaProfileRepository.UpdateAsync(socialMediaProfile);
                UpdatedSocialMediaProfileDto updatedSocialMediaProfileDto = _mapper.Map<UpdatedSocialMediaProfileDto>(updatedSocialMediaProfile);
                return updatedSocialMediaProfileDto;

            }
        }
    }
}
