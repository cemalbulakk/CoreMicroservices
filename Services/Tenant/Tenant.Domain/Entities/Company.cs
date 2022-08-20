using Tenant.Domain.Base;

namespace Tenant.Domain.Entities;

public class Company : BaseEntity
{
    public int TenantID { get; set; }
    public Tenant Tenant { get; set; }
    public string CompanyCode { get; set; }
    public string CompanyName { get; set; }
}