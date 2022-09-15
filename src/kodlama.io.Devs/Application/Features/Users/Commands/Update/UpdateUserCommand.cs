using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand:IRequest<UpdatedUserDto>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,UpdatedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _businessRules;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules businessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                User user = await _userRepository.GetAsync(u => u.Id == request.UserId);
                _businessRules.CheckUserExist(user);
                _businessRules.EmailCannotBeDublicated(request.Email);
                user.Email = request.Email;
                user.FirstName=request .FirstName;
                user.LastName=request .LastName;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                
                User updatedUser = await _userRepository.UpdateAsync(user);
                UpdatedUserDto updatedUserDto = _mapper.Map<UpdatedUserDto>(updatedUser);
                return updatedUserDto;




                
            }
        }

    }
}
