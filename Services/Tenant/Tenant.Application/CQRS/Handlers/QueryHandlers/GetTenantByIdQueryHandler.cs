using MediatR;
using Shared.Dtos;
using Tenant.Application.CQRS.Queries.Request;
using Tenant.Application.CQRS.Queries.Response;
using Tenant.Application.Mapping;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.QueryHandlers;

public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQueryRequest, Response<GetAllTenantQueryResponse>>
{
    private readonly TenantDbContext _tenantDbContext;

    public GetTenantByIdQueryHandler(TenantDbContext tenantDbContext)
    {
        _tenantDbContext = tenantDbContext;
    }

    public async Task<Response<GetAllTenantQueryResponse>> Handle(GetTenantByIdQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var tenant = await _tenantDbContext.Tenants.FindAsync(request.Id);
            if (tenant == null) return Response<GetAllTenantQueryResponse>.Fail("Tenant is not found", 404);
            var map = ObjectMapper.Mapper.Map<GetAllTenantQueryResponse>(tenant);
            return Response<GetAllTenantQueryResponse>.Success(map, 200, string.Empty);
        }
        catch (Exception e)
        {
            return Response<GetAllTenantQueryResponse>.Fail(e.Message, 500);
        }
    }
}