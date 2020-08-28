using Bermuda.Core.Repository.Repository;
using Bermuda.Core.Repository.UnitOfWork;
using Payment.Domain.Entity;
using System.Threading.Tasks;

namespace Payment.Domain.Repository
{
    public interface IBankProviderRepository : IRepository<BankProvider>
    {
        Task<BankProvider> GetByBankIdAsync(IUnitOfWork unitOfWork, long bankId);
    }
}
