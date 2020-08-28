using Bermuda.Infrastructure.Database.EF.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Core.Enumeration;

namespace Payment.Domain.EntityMapping.Mapping
{
    public class Provider : EntityBaseTypeConfiguration<Entity.Provider>
    {
        public override void EntityConfigure(EntityTypeBuilder<Entity.Provider> builder)
        {
            builder.Property<ProviderType>(x => x.ProviderType);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.BankProviders)
                   .WithOne(x => x.Provider)
                   .IsRequired()
                   .HasForeignKey(x => x.ProviderId);
        }
    }
}
