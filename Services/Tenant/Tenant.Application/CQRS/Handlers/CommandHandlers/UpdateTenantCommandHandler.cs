using AutoMapper;
using MediatR;
using Shared.Dtos;
using System.Linq;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Application.CQRS.Commands.Response;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.CommandHandlers;

public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommandRequest, Response<UpdateTenantCommandResponse>>
{
    private readonly TenantDbContext _tenantDbContext;
    private readonly IMapper _mapper;

    public UpdateTenantCommandHandler(TenantDbContext tenantDbContext, IMapper mapper)
    {
        _tenantDbContext = tenantDbContext;
        _mapper = mapper;
    }

    public async Task<Response<UpdateTenantCommandResponse>> Handle(UpdateTenantCommandRequest request, CancellationToken cancellationToken)
    {

        var tenant = await _tenantDbContext.Tenants.FindAsync(request.ID);
        if (tenant == null) return Response<UpdateTenantCommandResponse>.Fail("tenant not found!", 404);

        var map = _mapper.Map(request, tenant);
        _tenantDbContext.Tenants.Update(map);
        var result = await _tenantDbContext.SaveChangesAsync(cancellationToken);
        return result > 0
            ? Response<UpdateTenantCommandResponse>.Success(_mapper.Map<UpdateTenantCommandResponse>(tenant), 200, "Tenant updated.")
            : Response<UpdateTenantCommandResponse>.Fail("tenant not updated", 400);
    }
}