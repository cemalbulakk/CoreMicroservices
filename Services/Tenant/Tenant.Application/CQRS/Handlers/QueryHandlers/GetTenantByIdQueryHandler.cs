using AutoMapper;
using MediatR;
using Shared.Dtos;
using Tenant.Application.CQRS.Queries.Request;
using Tenant.Application.CQRS.Queries.Response;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.QueryHandlers;

public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQueryRequest, Response<GetAllTenantQueryResponse>>
{
    private readonly TenantDbContext _tenantDbContext;
    private readonly IMapper _mapper;

    public GetTenantByIdQueryHandler(TenantDbContext tenantDbContext, IMapper mapper)
    {
        _tenantDbContext = tenantDbContext;
        _mapper = mapper;
    }

    public async Task<Response<GetAllTenantQueryResponse>> Handle(GetTenantByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantDbContext.Tenants.FindAsync(request.Id);
        if (tenant == null) return Response<GetAllTenantQueryResponse>.Fail("Tenant is not found", 404);
        var map = _mapper.Map<GetAllTenantQueryResponse>(tenant);
        return Response<GetAllTenantQueryResponse>.Success(map, 200, string.Empty);
    }
}