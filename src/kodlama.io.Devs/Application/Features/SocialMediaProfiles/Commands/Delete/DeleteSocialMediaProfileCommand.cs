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

namespace Application.Features.SocialMediaProfiles.Commands.Delete
{
    public class DeleteSocialMediaProfileCommand:IRequest<DeletedSocialMediaProfileDto>
    {
        public int Id { get; set; }
        
        public class DeleteSocialMediaProfileCommandhandler:IRequestHandler<DeleteSocialMediaProfileCommand,DeletedSocialMediaProfileDto>
        {
            private readonly ISocialMediaProfileRepository _socialMediaRepository;
            private readonly IMapper _mapper;

            public DeleteSocialMediaProfileCommandhandler(ISocialMediaProfileRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSocialMediaProfileDto> Handle(DeleteSocialMediaProfileCommand request, CancellationToken cancellationToken)
            {
                SocialMediaProfile? socialMediaProfile = await _socialMediaRepository.GetAsync(s => s.Id == request.Id);
                SocialMediaProfile deletedSocialMediaProfile = await _socialMediaRepository.DeleteAsync(socialMediaProfile);
                DeletedSocialMediaProfileDto deletedSocialMediaProfileDto = _mapper.Map<DeletedSocialMediaProfileDto>(deletedSocialMediaProfile);
                return deletedSocialMediaProfileDto;
            }
        }
    }
}
