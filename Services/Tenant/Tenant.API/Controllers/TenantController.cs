using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBase;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Application.CQRS.Queries.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tenant.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TenantController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTenant(GetAllTenantQueryRequest request)
        {
            return CreateActionResultInstance(await _mediator.Send(new GetAllTenantQueryRequest(request.RequestParameter)));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTenantById(Guid id)
        {
            return CreateActionResultInstance(await _mediator.Send(new GetTenantByIdQueryRequest(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTenant([FromBody] CreateTenantCommandRequest createTenantCommandRequest)
        {
            return CreateActionResultInstance(await _mediator.Send(createTenantCommandRequest));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTenant([FromBody] UpdateTenantCommandRequest updateTenantCommandRequest)
        {
            return CreateActionResultInstance(await _mediator.Send(updateTenantCommandRequest));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTenant(Guid id)
        {
            return CreateActionResultInstance(await _mediator.Send(new DeleteTenantCommandRequest(id)));
        }
    }
}
