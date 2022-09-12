using Application.Features.GithubProfiles.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Commands.Create
{
    public class CreateGithubProfileCommand:IRequest<CreatedGithubProfileDto>
    {
        public int UserId { get; set; }
        public string GithubUserName { get; set; }

        public class CreateGithubProfileCommandHandler : IRequestHandler<CreateGithubProfileCommand, CreatedGithubProfileDto>
        {
            private readonly IGithubProfileRepository _githubProfileRepository;
            private readonly IMapper _mapper;

            public CreateGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper)
            {
                _githubProfileRepository = githubProfileRepository;
                _mapper = mapper;
            }

            public async Task<CreatedGithubProfileDto> Handle(CreateGithubProfileCommand request, CancellationToken cancellationToken)
            {
                GithubProfile? githubProfile = await _githubProfileRepository.GetAsync(g=>g.UserId ==request.UserId);
                GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
                GithubProfile createdGithubProfile = await _githubProfileRepository.AddAsync(mappedGithubProfile);
                CreatedGithubProfileDto createdGithubProfileDto = _mapper.Map<CreatedGithubProfileDto>(createdGithubProfile);
                return createdGithubProfileDto;


                
            }
        }
    }
}
