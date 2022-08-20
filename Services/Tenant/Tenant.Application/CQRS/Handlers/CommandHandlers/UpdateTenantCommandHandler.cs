using AutoMapper;
using MediatR;
using Shared.Dtos;
using System.Linq;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Application.CQRS.Commands.Response;
using Tenant.Application.Mapping;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.CommandHandlers;

public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommandRequest, Response<UpdateTenantCommandResponse>>
{
    private readonly TenantDbContext _tenantDbContext;

    public UpdateTenantCommandHandler(TenantDbContext tenantDbContext)
    {
        _tenantDbContext = tenantDbContext;
    }

    public async Task<Response<UpdateTenantCommandResponse>> Handle(UpdateTenantCommandRequest request, CancellationToken cancellationToken)
    {

        try
        {
            var tenant = await _tenantDbContext.Tenants.FindAsync(request.ID);
            if (tenant == null) return Response<UpdateTenantCommandResponse>.Fail("tenant not found!", 404);

            var map = ObjectMapper.Mapper.Map(request, tenant);
            _tenantDbContext.Tenants.Update(map);
            var result = await _tenantDbContext.SaveChangesAsync(cancellationToken);
            return result > 0
                ? Response<UpdateTenantCommandResponse>.Success(ObjectMapper.Mapper.Map<UpdateTenantCommandResponse>(tenant), 200, "Tenant updated.")
                : Response<UpdateTenantCommandResponse>.Fail("tenant not updated", 400);
        }
        catch (Exception e)
        {
            return Response<UpdateTenantCommandResponse>.Fail(e.Message, 400);
        }
    }
}