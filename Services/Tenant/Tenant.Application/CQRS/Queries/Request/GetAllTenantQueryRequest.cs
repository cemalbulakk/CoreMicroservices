using MediatR;
using Shared.Dtos;
using Tenant.Application.CQRS.Queries.Response;

namespace Tenant.Application.CQRS.Queries.Request;

public class GetAllTenantQueryRequest : IRequest<Response<List<GetAllTenantQueryResponse>>>
{
    public GetAllTenantQueryRequest(RequestParameter requestParameter)
    {
        RequestParameter = requestParameter;
    }

    public RequestParameter RequestParameter { get; set; }
}