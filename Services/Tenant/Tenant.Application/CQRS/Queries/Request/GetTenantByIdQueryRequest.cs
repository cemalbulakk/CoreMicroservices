using MediatR;
using Shared.Dtos;
using Tenant.Application.CQRS.Queries.Response;

namespace Tenant.Application.CQRS.Queries.Request;

public class GetTenantByIdQueryRequest : IRequest<Response<GetAllTenantQueryResponse>>
{
    public GetTenantByIdQueryRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}