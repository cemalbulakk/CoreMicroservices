namespace Tenant.Domain.Base;

public class BaseEntity
{
    public Guid ID { get; set; }
    public DateTime CreateDate { get; set; }
    public Guid CreateBy { get; set; }
    public DateTime? UpdateDate { get; set; }
    public Guid UpdateBy { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
}