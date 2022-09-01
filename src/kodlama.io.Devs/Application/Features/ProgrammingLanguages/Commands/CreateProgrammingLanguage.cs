using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands
{
    public partial class CreateProgrammingLanguage:IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguage, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;
            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository languageRepository, IMapper mapper, ProgrammingLanguageBusinessRules businessRules)
            {
                _repository = languageRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguage request, CancellationToken cancellationToken)
            {
                await _businessRules.ProgrammingLanguageNameCannotBeDublicatedWhenInserted(request.Name);
                ProgrammingLanguage mappedLanguage = _mapper.Map<ProgrammingLanguage>(request.Name);
                ProgrammingLanguage createdLanguage = await _repository.AddAsync(mappedLanguage);
                CreatedProgrammingLanguageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdLanguage);
                return createdProgrammingLanguageDto;


            }
        }

    }
}
