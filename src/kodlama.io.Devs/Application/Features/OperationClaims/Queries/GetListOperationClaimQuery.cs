using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries
{
    public class GetListOperationClaimQuery:IRequest<OperationClaimListModel>
    {
        public PageRequest  PageRequest { get; set; }

        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> claims = await _operationClaimRepository.GetListAsync(include: o => o.Include(o => o.Name),index:request.PageRequest.Page,size:request.PageRequest.PageSize);
                OperationClaimListModel result = _mapper.Map<OperationClaimListModel>(claims);
                return result;

            }
        }
    }
}
