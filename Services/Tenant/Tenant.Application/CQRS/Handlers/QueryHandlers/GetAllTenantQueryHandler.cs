using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using Tenant.Application.CQRS.Queries.Request;
using Tenant.Application.CQRS.Queries.Response;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.QueryHandlers;

public class GetAllTenantQueryHandler : IRequestHandler<GetAllTenantQueryRequest, Response<List<GetAllTenantQueryResponse>>>
{
    private readonly TenantDbContext _tenantDbContext;
    //private readonly IMapper _mapper;

    public GetAllTenantQueryHandler(TenantDbContext tenantDbContext)
    {
        _tenantDbContext = tenantDbContext;
    }

    public async Task<Response<List<GetAllTenantQueryResponse>>> Handle(GetAllTenantQueryRequest request, CancellationToken cancellationToken)
    {
        var tenants = await _tenantDbContext.Tenants.AsNoTracking().Select(tenant => new GetAllTenantQueryResponse()
        {
            ID = tenant.ID,
            TenantCode = tenant.TenantCode,
            TenantName = tenant.TenantName,
        }).Skip(request.RequestParameter.Skip).Take(request.RequestParameter.Take).ToListAsync(cancellationToken: cancellationToken);

        return Response<List<GetAllTenantQueryResponse>>.Success(tenants, 200);
    }
}