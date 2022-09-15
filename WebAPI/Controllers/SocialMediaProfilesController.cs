using Application.Features.SocialMediaProfiles.Commands.Create;
using Application.Features.SocialMediaProfiles.Commands.Delete;
using Application.Features.SocialMediaProfiles.Commands.Update;
using Application.Features.SocialMediaProfiles.Dtos;
using Application.Features.SocialMediaProfiles.Models;
using Application.Features.SocialMediaProfiles.Queries.GetListSocialMediaProfilesQuery;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaProfilesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaProfileCommand createSocialMediaProfile)
        {
            CreatedSocialMediaProfileDto result =  await Mediator.Send(createSocialMediaProfile);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaProfileCommand updateSocialMediaProfile)
        {
            UpdatedSocialMediaProfileDto result = await Mediator.Send(updateSocialMediaProfile);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialMediaProfileCommand deleteSocialMediaProfile)
        {
            DeletedSocialMediaProfileDto result = await Mediator.Send(deleteSocialMediaProfile);
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialMediaProfileQuery getListSocialMediaProfileQuery = new() { PageRequest = pageRequest };
            SocialMediaProfileListModel result = await Mediator.Send(getListSocialMediaProfileQuery);
            return Ok(result);
        }

    }
}
