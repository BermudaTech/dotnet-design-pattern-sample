using Payment.Core.Enumeration;

namespace Payment.Core.Contract.Payment
{
    public interface IPayment
    {
        ProviderType ProviderType { get; }
        PaymentResponse DoPayment(PaymentRequest request);
    }
}
