using Tenant.Domain.Base;

namespace Tenant.Domain.Entities;

public class Customer : BaseEntity
{
    public int CompanyID { get; set; }
    public Company Company { get; set; }

    public string CustomerCode { get; set; }
    public string CustomerName { get; set; }
}