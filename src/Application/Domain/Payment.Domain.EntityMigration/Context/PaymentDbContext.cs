using Bermuda.Core.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Payment.Domain.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Domain.EntityMigration.Context
{
    public class PaymentDbContext : DbContext
    {
        public DbSet<Bank> Bank { get; set; }
        public DbSet<BankBin> BankBin { get; set; }
        public DbSet<BankProvider> BankProvider { get; set; }
        public DbSet<Provider> Provider { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityMapping.Mapping.BankBin).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string appSettings = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            appSettings = appSettings ?? "Development";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"appsettings.{appSettings}.json")
                .Build();

            optionsBuilder.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                options => options.SetPostgresVersion(new Version(9, 5)));
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is EntityBaseWithLog entityBase)
                {
                    var now = DateTime.Now;

                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entityBase.UpdatedDate = now;
                            entityBase.UpdatedUser = "1";
                            entityBase.UpdatedIp = "127.0.0.1";
                            break;

                        case EntityState.Added:
                            entityBase.InsertedDate = now;
                            entityBase.InsertedUser = "1";
                            entityBase.InsertedIp = "127.0.0.1";
                            break;
                    }
                }
            }
        }

        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            return base.SaveChanges();
        }
    }
}
