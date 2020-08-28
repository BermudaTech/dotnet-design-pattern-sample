using Bermuda.Core.Repository.UnitOfWork;
using Bermuda.Infrastructure.Database.Repository;
using Payment.Domain.Entity;
using System.Threading.Tasks;

namespace Payment.Domain.Repository
{
    public class BankProviderRepository : Repository<BankProvider>, IBankProviderRepository
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public BankProviderRepository(
            IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<BankProvider> GetByBankIdAsync(IUnitOfWork unitOfWork, long bankId)
        {
            return await base.GetAsync(unitOfWork, x => x.Bank.Id == bankId);
        }
    }
}
