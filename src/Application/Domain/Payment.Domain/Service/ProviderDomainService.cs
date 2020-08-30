using Bermuda.Core.Repository.UnitOfWork;
using Payment.Core.Contract.Payment;
using Payment.Core.Enumeration;
using Payment.Domain.Entity;
using Payment.Domain.Repository;
using Payment.Domain.Validation;
using System.Threading.Tasks;

namespace Payment.Domain.Service
{
    public class ProviderDomainService
    {
        private readonly IProviderValidation providerValidation;
        private readonly IProviderRepository providerRepository;

        public ProviderDomainService(
            IProviderValidation providerValidation,
            IProviderRepository providerRepository)
        {
            this.providerValidation = providerValidation;
            this.providerRepository = providerRepository;
        }

        public PaymentProvider GetValidPaymentProviderByType(
            ProviderType providerType)
        {
            return providerValidation.GetValidPaymentProviderByType(providerType);
        }

        public async Task<Provider> GetValidProviderByIdAsync(
            IUnitOfWork unitOfWork,
            long Id)
        {
            return await providerValidation.GetValidProviderByIdAsync(unitOfWork, Id);
        }
    }
}
