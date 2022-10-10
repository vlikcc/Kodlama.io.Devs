using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.Update
{
    public class UpdateOperationClaimCommand:IRequest<UpdatedOperationCliamDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationCliamDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedOperationCliamDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
                operationClaim.Name = request.Name;
                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(operationClaim);
                OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
                UpdatedOperationCliamDto result = _mapper.Map<UpdatedOperationCliamDto>(updatedOperationClaim);
                return result;

            }
        }
    }
}
