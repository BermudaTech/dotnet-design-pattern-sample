using Bermuda.Core.Repository.UnitOfWork;
using Payment.Core.Contract.Payment;
using Payment.Core.Enumeration;
using Payment.Domain.Entity;
using System.Threading.Tasks;

namespace Payment.Domain.Validation
{
    public interface IProviderValidation
    {
        IPaymentProvider GetValidPaymentProviderByType(ProviderType providerType);
        Task<Provider> GetValidProviderByIdAsync(IUnitOfWork unitOfWork, long Id);
    }
}
