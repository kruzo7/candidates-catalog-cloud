using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CVGatorBeta.Admin.EntityFramework.Extensions
{
    public static class AuditExtension
    {
        public static void AddAudit(this ChangeTracker changeTracker)
        {
            changeTracker.DetectChanges();
            IEnumerable<EntityEntry> entities =
                changeTracker
                    .Entries()
                    .Where(t => t.Entity is IEntityBase &&
                    (
                        t.State == EntityState.Deleted
                        || t.State == EntityState.Added
                        || t.State == EntityState.Modified
                    ));

            if (!entities.Any())
                return;

            DateTime timestamp = DateTime.UtcNow;

            string user = "TestUserAudit";

            foreach (EntityEntry entry in entities)
            {
                IEntityBase entity = (IEntityBase)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.AudCreateOn = timestamp;
                        entity.AudCreateBy = user;
                        entity.AudModifyOn = timestamp;
                        entity.AudModifyBy = user;
                        break;
                    case EntityState.Modified:
                        entry.Property(nameof(entity.AudCreateBy)).IsModified = false;
                        entry.Property(nameof(entity.AudCreateOn)).IsModified = false;
                        entity.AudModifyOn = timestamp;
                        entity.AudModifyBy = user;
                        break;

                }
            }

        }
    }
}
