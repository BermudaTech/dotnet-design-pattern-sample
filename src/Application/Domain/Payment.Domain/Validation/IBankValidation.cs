using Bermuda.Core.Repository.UnitOfWork;
using Payment.Domain.Entity;
using System.Threading.Tasks;

namespace Payment.Domain.Validation
{
    public interface IBankValidation
    {
        Task<BankBin> GetValidBankBinByCardNumberAsync(IUnitOfWork unitOfWork, string cardNumber);
        Task<BankProvider> GetValidBankProviderByBankIdAsync(IUnitOfWork unitOfWork, long bankId);
    }
}
