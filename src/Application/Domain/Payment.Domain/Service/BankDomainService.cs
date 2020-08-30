using Bermuda.Core.Repository.UnitOfWork;
using Payment.Core.Contract.Payment;
using Payment.Domain.Entity;
using Payment.Domain.Repository;
using Payment.Domain.Validation;
using System.Threading.Tasks;

namespace Payment.Domain.Service
{
    public class BankDomainService : IBankBinQuery
    {
        private readonly IBankValidation bankValidation;
        private readonly IBankBinRepository bankBinRepository;

        public BankDomainService(
            IBankValidation bankValidation,
            IBankBinRepository bankBinRepository)
        {
            this.bankValidation = bankValidation;
            this.bankBinRepository = bankBinRepository;
        }

        public Task<GetBankByBinNumberResponse> GetBankByBinNumberAsync(GetBankByBinNumberRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BankBin> GetValidBankBinByCardNumberAsync(
            IUnitOfWork unitOfWork,
            string cardNumber)
        {
            return await bankValidation.GetValidBankBinByCardNumberAsync(unitOfWork, cardNumber);
        }

        public async Task<BankProvider> GetValidBankProviderByBankIdAsync(
            IUnitOfWork unitOfWork,
            long bankId)
        {
            return await bankValidation.GetValidBankProviderByBankIdAsync(unitOfWork, bankId);
        }
    }
}
