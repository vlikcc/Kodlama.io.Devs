using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand:IRequest<User>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler:IRequestHandler<DeleteUserCommand,User>
        {
            private readonly IUserRepository _userRepository;
            

            public DeleteUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
               
            }

            public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u=>u.Id == request.Id);
                User deletedUser = await _userRepository.DeleteAsync(user);
                return deletedUser;

            }
        }
    }
}
