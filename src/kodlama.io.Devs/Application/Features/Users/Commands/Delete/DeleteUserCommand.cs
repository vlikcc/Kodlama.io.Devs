using Application.Features.Users.Rules;
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
            private readonly UserBusinessRules _businessRules;
            

            public DeleteUserCommandHandler(IUserRepository userRepository, UserBusinessRules businessRules)
            {
                _userRepository = userRepository;
                _businessRules = businessRules; 
               
            }

            public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u=>u.Id == request.Id);
                _businessRules.CheckUserExist(user);
                User deletedUser = await _userRepository.DeleteAsync(user);
                return deletedUser;

            }
        }
    }
}
