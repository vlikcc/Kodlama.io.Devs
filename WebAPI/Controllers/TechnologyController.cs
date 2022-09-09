
using Application.Features.Technologies.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Requests;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Commands.Update;
using Application.Features.Technologies.Commands.Delete;
using Application.Features.Technologies.Queries.GetListTechnologyQuery;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetByIdTechnologyQuery;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto result = await Mediator.Send(deleteTechnologyCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery )
        {
            TechnologyGetByIdDto result = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(result);
        }
    }
}
