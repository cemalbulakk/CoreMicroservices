namespace Tenant.Application.CQRS.Queries.Response;

public class GetAllTenantQueryResponse
{
    public Guid ID { get; set; }
    public string TenantCode { get; set; }
    public string TenantName { get; set; }
}