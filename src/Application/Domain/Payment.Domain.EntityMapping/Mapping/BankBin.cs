using Bermuda.Infrastructure.Database.EF.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payment.Domain.EntityMapping.Mapping
{
    public class BankBin : EntityBaseTypeConfiguration<Entity.BankBin>
    {
        public override void EntityConfigure(EntityTypeBuilder<Entity.BankBin> builder)
        {
            builder.Property(x => x.BinNumber);
            builder.Property(x => x.CardType).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Organization).IsRequired().HasMaxLength(25);
            builder.Property(x => x.IsCommercialCard);
            builder.Property(x => x.IsSupportInstallment);
            builder.Property(x => x.IsActive);
        }
    }
}
