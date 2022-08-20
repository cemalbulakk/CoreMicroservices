using AutoMapper;
using MediatR;
using Shared.Dtos;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Application.CQRS.Commands.Response;
using Tenant.Application.Mapping;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.CommandHandlers;

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommandRequest, Response<CreateTenantCommandResponse>>
{
    private readonly TenantDbContext _tenantDbContext;

    public CreateTenantCommandHandler(TenantDbContext tenantDbContext)
    {
        _tenantDbContext = tenantDbContext;
    }

    public async Task<Response<CreateTenantCommandResponse>> Handle(CreateTenantCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var tenant = ObjectMapper.Mapper.Map<Domain.Entities.Tenant>(request);
            await _tenantDbContext.Tenants.AddAsync(tenant, cancellationToken);
            var result = await _tenantDbContext.SaveChangesAsync(cancellationToken);
            return result > 0
                ? Response<CreateTenantCommandResponse>.Success(ObjectMapper.Mapper.Map<CreateTenantCommandResponse>(tenant), 200, "tenant created")
                : Response<CreateTenantCommandResponse>.Fail("tenant is not created", 400);
        }
        catch (Exception e)
        {
            return Response<CreateTenantCommandResponse>.Fail(e.Message, 500);
        }
    }
}