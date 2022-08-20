using MediatR;
using Shared.Dtos;
using Tenant.Application.CQRS.Commands.Request;
using Tenant.Infrastructure.Context;

namespace Tenant.Application.CQRS.Handlers.CommandHandlers;

public class DeleteTenantCommandHandler : IRequestHandler<DeleteTenantCommandRequest, Response<NoContent>>
{
    private readonly TenantDbContext _tenantDbContext;

    public DeleteTenantCommandHandler(TenantDbContext tenantDbContext)
    {
        _tenantDbContext = tenantDbContext;
    }

    public async Task<Response<NoContent>> Handle(DeleteTenantCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var tenant = await _tenantDbContext.Tenants.FindAsync(request.Id);
            if (tenant == null) return Response<NoContent>.Fail("Tenant not found.", 404);

            tenant.IsActive = false;
            tenant.IsDelete = true;

            _tenantDbContext.Tenants.Update(tenant);
            await _tenantDbContext.SaveChangesAsync(cancellationToken);
            return Response<NoContent>.Success(200, "Tenant deleted.");
        }
        catch (Exception e)
        {
            return Response<NoContent>.Fail(e.Message, 500);
        }
    }
}