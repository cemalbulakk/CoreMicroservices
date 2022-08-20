using MediatR;
using Shared.Dtos;
using Tenant.Application.CQRS.Commands.Response;

namespace Tenant.Application.CQRS.Commands.Request;

public class UpdateTenantCommandRequest : IRequest<Response<UpdateTenantCommandResponse>>
{
    public Guid ID { get; set; }
    public string TenantCode { get; set; }
    public string TenantName { get; set; }
}