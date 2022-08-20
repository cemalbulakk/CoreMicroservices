using AutoMapper;
using MediatR;
using Shared.Dtos;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Application.CQRS.Commands.Response;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.CommandHandlers;

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommandRequest, Response<CreateTenantCommandResponse>>
{
    private readonly TenantDbContext _tenantDbContext;
    private readonly IMapper _mapper;

    public CreateTenantCommandHandler(TenantDbContext tenantDbContext, IMapper mapper)
    {
        _tenantDbContext = tenantDbContext;
        _mapper = mapper;
    }

    public async Task<Response<CreateTenantCommandResponse>> Handle(CreateTenantCommandRequest request, CancellationToken cancellationToken)
    {
        var tenant = _mapper.Map<Domain.Entities.Tenant>(request);
        await _tenantDbContext.Tenants.AddAsync(tenant, cancellationToken);
        var result = await _tenantDbContext.SaveChangesAsync(cancellationToken);
        return result > 0
            ? Response<CreateTenantCommandResponse>.Success(_mapper.Map<CreateTenantCommandResponse>(tenant), 200)
            : Response<CreateTenantCommandResponse>.Fail("tenant is not created", 400);
    }
}