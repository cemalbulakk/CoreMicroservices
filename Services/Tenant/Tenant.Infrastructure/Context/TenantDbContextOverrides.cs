using Microsoft.EntityFrameworkCore;
using Tenant.Domain.Base;

namespace Tenant.Infrastructure.Context;
public partial class TenantDbContext
{
    private void OnBeforeSaving()
    {
        var entries = ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            switch (entry.Entity)
            {
                case BaseEntity tractable:
                    {
                        var now = DateTime.Now;
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                tractable.CreateDate = now;
                                tractable.UpdateDate = now;
                                tractable.CreateBy = Guid.NewGuid(); //1
                                tractable.IsActive = true;
                                tractable.IsDelete = false;
                                break;

                            case EntityState.Modified:
                                tractable.UpdateDate = now;
                                tractable.UpdateBy = Guid.NewGuid();//1
                                break;

                            case EntityState.Detached:
                            case EntityState.Unchanged:
                            case EntityState.Deleted:
                                tractable.IsActive = false;
                                tractable.IsDelete = true;
                                tractable.UpdateDate = now;
                                tractable.UpdateBy = Guid.NewGuid();//1
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    }
            }
        }
    }



    public override int SaveChanges()
    {
        OnBeforeSaving();
        return base.SaveChanges();
    }



    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();
        return base.SaveChangesAsync(cancellationToken);
    }
}