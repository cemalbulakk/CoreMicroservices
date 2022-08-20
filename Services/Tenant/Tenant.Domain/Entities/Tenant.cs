using Tenant.Domain.Base;

namespace Tenant.Domain.Entities;

public class Tenant : BaseEntity
{
    public string TenantCode { get; set; }
    public string TenantName { get; set; }

    public List<Company> Companies { get; set; }
}