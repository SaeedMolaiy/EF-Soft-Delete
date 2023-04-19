using EF_Soft_Delete.Entities;
using EF_Soft_Delete.Markers;

using Microsoft.EntityFrameworkCore;

namespace EF_Soft_Delete.Context;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<User> Users { get; set; }

    /// <inheritdoc />
    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();

        foreach (var entityEntry in ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted))
        {
            if (entityEntry is not ISoftDeletable entity)
            {
                continue;
            }

            entityEntry.State = EntityState.Modified;
            entity.IsDeleted = true;
        }

        return base.SaveChanges();
    }
}