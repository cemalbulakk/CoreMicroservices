using AutoMapper;
using MediatR;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.CommandHandlers;

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommandRequest, bool>
{
    private readonly TenantDbContext _tenantDbContext;
    private readonly IMapper _mapper;

    public CreateTenantCommandHandler(TenantDbContext tenantDbContext, IMapper mapper)
    {
        _tenantDbContext = tenantDbContext;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateTenantCommandRequest request, CancellationToken cancellationToken)
    {
        var tenant = _mapper.Map<Domain.Entities.Tenant>(request);
        await _tenantDbContext.Tenants.AddAsync(tenant, cancellationToken);
        var result = await _tenantDbContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}