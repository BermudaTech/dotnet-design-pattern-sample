using Bermuda.Infrastructure.Database.EF.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Payment.Domain.EntityMapping.Mapping
{
    public class BankProvider : EntityBaseTypeConfiguration<Entity.BankProvider>
    {
        public override void EntityConfigure(EntityTypeBuilder<Entity.BankProvider> builder)
        {
            builder.Property(x => x.Configuration).IsRequired().HasColumnType("text");
        }
    }
}
