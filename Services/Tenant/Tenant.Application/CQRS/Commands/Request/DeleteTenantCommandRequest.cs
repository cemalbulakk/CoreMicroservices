using MediatR;
using Shared.Dtos;

namespace Tenant.Application.CQRS.Commands.Request;

public class DeleteTenantCommandRequest : IRequest<Response<NoContent>>
{
    public DeleteTenantCommandRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}