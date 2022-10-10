using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.Delete
{
    public class DeleteOperationClaimCommand:IRequest<DeletedOperationClaimDto>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(operationClaim);
                OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(mappedOperationClaim);
                DeletedOperationClaimDto result = _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);
                return result;                
            }
        }
    }
}
