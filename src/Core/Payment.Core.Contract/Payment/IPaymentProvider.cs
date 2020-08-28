using Payment.Core.Enumeration;

namespace Payment.Core.Contract.Payment
{
    public interface IPaymentProvider
    {
        ProviderType ProviderType { get; }
        PaymentResponse DoPayment(PaymentRequest request);
    }
}
