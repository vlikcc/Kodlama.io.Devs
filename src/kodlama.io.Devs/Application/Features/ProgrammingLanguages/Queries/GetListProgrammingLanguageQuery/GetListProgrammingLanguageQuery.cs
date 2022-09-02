using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery:IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest pageRequest { get; set; }

        public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly IMapper _mapper;
            

            public GetListProgrammingLanguageQueryHandler( IProgrammingLanguageRepository programmingLanguageRepository,IMapper mapper)
            {
                _repository = programmingLanguageRepository;
                _mapper = mapper;   
                
            }
            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> languages = await _repository.GetListAsync(index:request.pageRequest.Page,size:request.pageRequest.PageSize);
                ProgrammingLanguageListModel mappadprogrammingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(languages);
                return mappadprogrammingLanguageListModel;
            }
        }
    }
}
