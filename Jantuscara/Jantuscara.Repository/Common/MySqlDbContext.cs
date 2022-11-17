using Jantuscara.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jantuscara.Repository
{
    public class MySqlDbContext : DbContext
    {
        // DbSets
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<RequestItem> RequestItems { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public MySqlDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public override int SaveChanges()
        {
            AdjustDates();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AdjustDates();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AdjustDates();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void AdjustDates()
        {
            var added = ChangeTracker.Entries<BaseDomain>().Where(e => e.State == EntityState.Added).ToList();

            added.ForEach(e =>
            {
                DateTime dateTime = DateTime.UtcNow;

                e.Property(x => x.CreatedAt).CurrentValue = dateTime;
                e.Property(x => x.CreatedAt).IsModified = true;
                e.Property(x => x.UpdatedAt).CurrentValue = dateTime;
                e.Property(x => x.UpdatedAt).IsModified = true;
            });

            var modified = ChangeTracker.Entries<BaseDomain>().Where(e => e.State == EntityState.Modified).ToList();

            modified.ForEach(e =>
            {
                e.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                e.Property(x => x.UpdatedAt).IsModified = true;

                e.Property(x => x.CreatedAt).CurrentValue = e.Property(x => x.CreatedAt).OriginalValue;
                e.Property(x => x.CreatedAt).IsModified = false;
            });
        }
    }
}