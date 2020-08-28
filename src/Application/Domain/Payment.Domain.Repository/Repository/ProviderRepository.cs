using Bermuda.Core.Repository.UnitOfWork;
using Bermuda.Infrastructure.Database.Repository;
using Payment.Domain.Entity;

namespace Payment.Domain.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public ProviderRepository(
            IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
