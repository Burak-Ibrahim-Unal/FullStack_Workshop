using Application.Features.Maintenances.Commands;
using Application.Features.Maintenances.Queries.GetByIdMaintenance;
using Application.Features.Maintenances.Queries.GetMaintenanceList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenancesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetMaintenanceListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);

            //v2
            //GetMaintenanceListQuery getMaintenanceListQuery = new() { PageRequest = pageRequest };
            //var result = await Mediator.Send(getMaintenanceListQuery);
            //return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetMaintenanceByIdQuery getMaintenanceByIdQuery)
        {
            var result = await Mediator.Send(getMaintenanceByIdQuery);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateMaintenanceCommand createMaintenanceCommand)
        {
            var result = await Mediator.Send(createMaintenanceCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMaintenanceCommand updateMaintenanceCommand)
        {
            var result = await Mediator.Send(updateMaintenanceCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMaintenanceCommand deleteMaintenanceCommand)
        {
            var result = await Mediator.Send(deleteMaintenanceCommand);
            return Ok(result);
        }
    }
}