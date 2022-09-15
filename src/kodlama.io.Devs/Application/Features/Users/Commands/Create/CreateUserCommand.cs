using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommand:IRequest<UserForRegisterDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand,UserForRegisterDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _businessRules;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper,UserBusinessRules userBusinessRules )
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _businessRules = userBusinessRules;
            }

            public async Task<UserForRegisterDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                User createdUser = _mapper.Map<User>(request);
                createdUser.Status = true;
                createdUser.PasswordSalt=passwordSalt;
                createdUser.PasswordHash=passwordHash;
                createdUser.AuthenticatorType = AuthenticatorType.Email;
                await _businessRules.EmailCannotBeDublicated(createdUser.Email);                
                await _userRepository.AddAsync(createdUser); 
                UserForRegisterDto createdUserDto = _mapper.Map<UserForRegisterDto>(createdUser);
                return createdUserDto;
                
                
            }
        }
    }
}
