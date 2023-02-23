using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Todo_App.Domain.Common;

namespace Todo_App.Infrastructure.Persistence.Extensions;
public static class ChangeTrackerExtension
{
    public static void SetAuditProperties(this ChangeTracker changeTracker)
    {
        changeTracker.DetectChanges();
        IEnumerable<EntityEntry> entities =
            changeTracker
                .Entries()
                .Where(t => t.Entity is IBaseAuditableEntity && t.State == EntityState.Deleted);

        if (entities.Any())
        {
            foreach (EntityEntry entry in entities)
            {
                IBaseAuditableEntity entity = (IBaseAuditableEntity)entry.Entity;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
