using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBase;
using Shared.Dtos;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Application.CQRS.Queries.Request;
using Tenant.Application.CQRS.Queries.Response;

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
            var result = await _mediator.Send(new GetAllTenantQueryRequest(request.RequestParameter));
            return CreateActionResultInstance(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTenantById(Guid id)
        {
            var result = await _mediator.Send(new GetTenantByIdQueryRequest(id));
            return CreateActionResultInstance(Response<GetAllTenantQueryResponse>.Success(result, 200));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTenant([FromBody] CreateTenantCommandRequest tenantCreateDto)
        {
            var result = await _mediator.Send(new CreateTenantCommandRequest() { TenantCode = tenantCreateDto.TenantCode, TenantName = tenantCreateDto.TenantName });
            return result
                ? CreateActionResultInstance(Response<NoContent>.Success(200))
                : CreateActionResultInstance(Response<NoContent>.Fail("Tenant is not create", 400));
        }
    }
}
