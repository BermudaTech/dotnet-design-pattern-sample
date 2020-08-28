using Bermuda.Core.Repository.UnitOfWork;
using Bermuda.Infrastructure.Database.Repository;
using Payment.Domain.Entity;

namespace Payment.Domain.Repository
{
    public class BankBinRepository : Repository<BankBin>, IBankBinRepository
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public BankBinRepository(
            IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }
    }
}
