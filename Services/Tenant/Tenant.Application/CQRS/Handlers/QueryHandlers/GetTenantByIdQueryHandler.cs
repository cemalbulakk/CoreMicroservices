using AutoMapper;
using MediatR;
using Tenant.Application.CQRS.Queries.Request;
using Tenant.Application.CQRS.Queries.Response;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.QueryHandlers;

public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQueryRequest, GetAllTenantQueryResponse>
{
    private readonly TenantDbContext _tenantDbContext;
    private readonly IMapper _mapper;

    public GetTenantByIdQueryHandler(TenantDbContext tenantDbContext, IMapper mapper)
    {
        _tenantDbContext = tenantDbContext;
        _mapper = mapper;
    }

    public async Task<GetAllTenantQueryResponse> Handle(GetTenantByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantDbContext.Tenants.FindAsync(request.Id);
        var map = _mapper.Map<GetAllTenantQueryResponse>(tenant);
        return map;
    }
}