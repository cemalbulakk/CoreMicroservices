using MediatR;

namespace Tenant.Application.CQRS.Commands.Request;

public class CreateTenantCommandRequest : IRequest<bool>
{
    public string TenantCode { get; set; }
    public string TenantName { get; set; } 
}