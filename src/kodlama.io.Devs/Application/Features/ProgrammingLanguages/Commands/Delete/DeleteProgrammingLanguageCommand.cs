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

namespace Application.Features.ProgrammingLanguages.Commands.Delete
{
    public  partial class DeleteProgrammingLanguageCommand:IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLangualgeCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;
            public DeleteProgrammingLangualgeCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository,IMapper mapper,ProgrammingLanguageBusinessRules businessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;   
                _businessRules = businessRules;
               
            }
            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                await _businessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
                ProgrammingLanguage mappadLanguage = _mapper.Map<ProgrammingLanguage>(programmingLanguage);                
                ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(mappadLanguage);               
                DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);
                return deletedProgrammingLanguageDto;
            }
        }
    }
}
