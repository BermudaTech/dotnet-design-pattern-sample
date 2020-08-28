using Bermuda.Core.Logger;
using Bermuda.Core.Serialization;
using Payment.Core.Contract.Payment;
using Payment.Core.Enumeration;

namespace Payment.Integration.PAYTEN
{
    public class PAYTENPaymentIntegration : IPaymentProvider
    {
        public ProviderType ProviderType => ProviderType.PAYTEN;

        private readonly ILogger logger;
        private readonly IJsonSerializer jsonSerializer;

        public PAYTENPaymentIntegration(
            ILogger logger,
            IJsonSerializer jsonSerializer)
        {
            this.logger = logger;
            this.jsonSerializer = jsonSerializer;
        }

        public PaymentResponse DoPayment(PaymentRequest request)
        {
            PAYTENConfiguration paytenConfiguration = jsonSerializer.Deserialize<PAYTENConfiguration>(request.Configuration);

            return new PaymentResponse
            {
                IsSucceed = true
            };
        }
    }
}
