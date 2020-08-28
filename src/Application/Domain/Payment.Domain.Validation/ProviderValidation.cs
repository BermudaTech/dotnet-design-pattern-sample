using Bermuda.Core;
using Bermuda.Core.Repository.UnitOfWork;
using Payment.Core.Contract.Payment;
using Payment.Core.Enumeration;
using Payment.Domain.Entity;
using Payment.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Domain.Validation
{
    public class ProviderValidation : IProviderValidation
    {
        private readonly IEnumerable<IPaymentProvider> paymentProviders;
        private readonly IProviderRepository providerRepository;

        public ProviderValidation(
            IEnumerable<IPaymentProvider> paymentProviders,
            IProviderRepository providerRepository)
        {
            this.paymentProviders = paymentProviders;
            this.providerRepository = providerRepository;
        }

        public IPaymentProvider GetValidPaymentProviderByType(ProviderType providerType)
        {
            IPaymentProvider paymentProvider = paymentProviders.Where(x => x.ProviderType == providerType).FirstOrDefault();
            if (paymentProvider == null)
            {
                throw new BusinessException("Payment provider not found!");
            }

            return paymentProvider;
        }

        public async Task<Provider> GetValidProviderByIdAsync(IUnitOfWork unitOfWork, long Id)
        {
            Provider provider = await providerRepository.GetByIdAsync(unitOfWork, Id);
            if (provider is null)
            {
                throw new BusinessException("Provider not found!");
            }

            return provider;
        }
    }
}
