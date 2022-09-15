using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Login
{
    public class LoginUserCommand:IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _businessRules;
            private readonly ITokenHelper _tokenHelper;

            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules businessRules, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _businessRules = businessRules;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(u => u.Email == request.Email);
                 _businessRules.CheckUserExist(user);

                await _businessRules.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);

                var userClaims = _userRepository.GetClaims(user);
                AccessToken accessToken = _tokenHelper.CreateToken(user,userClaims);
                return accessToken;
            }
        }
    }
}
