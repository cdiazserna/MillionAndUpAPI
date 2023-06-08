using Microsoft.EntityFrameworkCore;
using MillionAndUp.Models;

namespace MillionAndUp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateAuditingFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditingFields();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);
        }

        private void UpdateAuditingFields()
        {
            foreach (var entity in ChangeTracker.Entries<AuditBase>())
            {
                switch (entity.State)
                {
                    case EntityState.Modified:
                        entity.Entity.Updated = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entity.Entity.Inserted = DateTime.UtcNow;

                        break;
                }
            }
        }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }

    }
}