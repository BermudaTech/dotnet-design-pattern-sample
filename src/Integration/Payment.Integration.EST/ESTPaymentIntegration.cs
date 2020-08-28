using Bermuda.Core.Logger;
using Bermuda.Core.Serialization;
using Payment.Core.Contract.Payment;
using Payment.Core.Enumeration;

namespace Payment.Integration.EST
{
    public class ESTPaymentIntegration : IPaymentProvider
    {
        public ProviderType ProviderType => ProviderType.EST;

        private readonly ILogger logger;
        private readonly IJsonSerializer jsonSerializer;

        public ESTPaymentIntegration(
            ILogger logger,
            IJsonSerializer jsonSerializer)
        {
            this.logger = logger;
            this.jsonSerializer = jsonSerializer;
        }

        public PaymentResponse DoPayment(PaymentRequest request)
        {
            ESTConfiguration eSTConfiguration = jsonSerializer.Deserialize<ESTConfiguration>(request.Configuration);

            return new PaymentResponse
            {
                IsSucceed = true
            };
        }
    }
}
