using Bermuda.Infrastructure.Database.EF.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payment.Domain.EntityMapping.Mapping
{
    public class Bank : EntityBaseTypeConfiguration<Entity.Bank>
    {
        public override void EntityConfigure(EntityTypeBuilder<Entity.Bank> builder)
        {
            builder.Property(x => x.Code);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.BankBins)
                   .WithOne(x => x.Bank)
                   .IsRequired()
                   .HasForeignKey(x => x.BankId);

            builder.HasMany(x => x.BankProviders)
                   .WithOne(x => x.Bank)
                   .IsRequired();
        }
    }
}
