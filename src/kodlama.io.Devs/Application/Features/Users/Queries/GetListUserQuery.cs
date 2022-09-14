using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries
{
    public class GetListUserQuery:IRequest<UserListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListQueryHandler:IRequestHandler<GetListUserQuery,UserListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users); 
                return mappedUserListModel;
            }
        }
    }
}
