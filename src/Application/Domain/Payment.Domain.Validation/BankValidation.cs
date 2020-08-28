using Bermuda.Core;
using Bermuda.Core.Repository.UnitOfWork;
using Payment.Domain.Entity;
using Payment.Domain.Repository;
using System.Threading.Tasks;

namespace Payment.Domain.Validation
{
    public class BankValidation : IBankValidation
    {
        private readonly IBankBinRepository bankBinRepository;
        private readonly IBankProviderRepository bankProviderRepository;

        public BankValidation(
            IBankBinRepository bankBinRepository,
            IBankProviderRepository bankProviderRepository)
        {
            this.bankBinRepository = bankBinRepository;
            this.bankProviderRepository = bankProviderRepository;
        }

        public async Task<BankBin> GetValidBankBinByCardNumberAsync(IUnitOfWork unitOfWork, string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 16)
            {
                throw new BusinessException("Card number is not valid!");
            }

            int binNumber = cardNumber.Substring(0, 6).xToInt();
            if (binNumber <= 0)
            {
                throw new BusinessException("Card number bin is not valid!");
            }

            BankBin bankBin = await bankBinRepository.GetByBinNumberAsync(unitOfWork, binNumber);
            if (bankBin is null)
            {
                throw new BusinessException("Bank not found by card number!");
            }

            return bankBin;
        }

        public async Task<BankProvider> GetValidBankProviderByBankIdAsync(IUnitOfWork unitOfWork, long bankId)
        {
            BankProvider bankProvider = await bankProviderRepository.GetByBankIdAsync(unitOfWork, bankId);
            if (bankProvider is null)
            {
                throw new BusinessException("Provider not found for bank!");
            }

            return bankProvider;
        }
    }
}
