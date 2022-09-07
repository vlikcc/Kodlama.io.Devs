using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.Update
{
    public partial class UpdateProgrammingLanguageCommand:IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;
            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository,IMapper mapper,ProgrammingLanguageBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository; 
                _mapper = mapper;
                _businessRules = businessRules;
            }
            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                await _businessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
                await _businessRules.ProgrammingLanguageNameCannotBeDublicatedWhenInserted(request.Name);
                programmingLanguage.Name=request.Name;

                ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);   
                return updatedProgrammingLanguageDto;



                

            }
        }
    }
}
