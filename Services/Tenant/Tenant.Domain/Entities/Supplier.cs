using Tenant.Domain.Base;

namespace Tenant.Domain.Entities;

public class Supplier : BaseEntity
{
    public int CompanyID { get; set; }
    public Company Company { get; set; }

    public string SupplierCode { get; set; }
    public string SupplierName { get; set; }
}