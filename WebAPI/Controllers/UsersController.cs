using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Login;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries;
using Core.Application.Requests;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginRequest)
        {
            AccessToken result = await Mediator.Send(loginRequest);
            return Ok( result);
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] CreateUserCommand createUser)
        {
            UserForRegisterDto result = await Mediator.Send(createUser);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUser)
        {
            UpdatedUserDto result = await Mediator.Send(updateUser);
            return Ok(result);
        }

        [HttpPost("Delete")]

        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUser)
        {
            User result = await Mediator.Send(deleteUser);
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            UserListModel result = await Mediator.Send(getListUserQuery);
            return Ok(result);   
        }
    }
}
