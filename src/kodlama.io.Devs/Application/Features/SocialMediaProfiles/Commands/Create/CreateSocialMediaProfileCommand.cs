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

namespace Application.Features.SocialMediaProfiles.Commands.Create
{
    public class CreateSocialMediaProfileCommand:IRequest<CreatedSocialMediaProfileDto>
    {
        public int UserId { get; set; }
        public string SocialMediaUserName { get; set; }
        public string ProfileUrl { get; set; }

        public class CreateSocialMediaProfileCommandHandler : IRequestHandler<CreateSocialMediaProfileCommand, CreatedSocialMediaProfileDto>
        {
            private readonly ISocialMediaProfileRepository _socialMediaProfileRepository;
            private readonly IMapper _mapper;

            public CreateSocialMediaProfileCommandHandler(ISocialMediaProfileRepository socialMediaProfileRepository, IMapper mapper)
            {
                _socialMediaProfileRepository = socialMediaProfileRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSocialMediaProfileDto> Handle(CreateSocialMediaProfileCommand request, CancellationToken cancellationToken)
            {
                SocialMediaProfile? githubProfile = await _socialMediaProfileRepository.GetAsync(g=>g.UserId ==request.UserId);
                SocialMediaProfile mappedGithubProfile = _mapper.Map<SocialMediaProfile>(request);
                SocialMediaProfile createdGithubProfile = await _socialMediaProfileRepository.AddAsync(mappedGithubProfile);
                CreatedSocialMediaProfileDto createdSocialMediaProfileDto = _mapper.Map<CreatedSocialMediaProfileDto>(createdGithubProfile);
                return createdSocialMediaProfileDto;


                
            }
        }
    }
}
