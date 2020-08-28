using Bermuda.Core.Database.ContextFactory;
using Payment.Domain.EntityMigration.Context;

namespace Payment.Domain.Repository.ContextFactory
{
    public class DbContextFactory : IDbContextFactory
    {
        public DbContextModel GetDbContextModel()
        {
            return new DbContextModel
            {
                DbContext = new PaymentDbContext()
            };
        }
    }
}
