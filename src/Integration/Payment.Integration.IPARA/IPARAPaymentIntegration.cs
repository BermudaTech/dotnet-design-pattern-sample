using Bermuda.Core.Logger;
using Bermuda.Core.Serialization;
using Payment.Core.Contract.Payment;
using Payment.Core.Enumeration;

namespace Payment.Integration.IPARA
{
    public class IPARAPaymentIntegration : IPaymentProvider
    {
        public ProviderType ProviderType => ProviderType.IPARA;

        private readonly ILogger logger;
        private readonly IJsonSerializer jsonSerializer;

        public IPARAPaymentIntegration(
            ILogger logger,
            IJsonSerializer jsonSerializer)
        {
            this.logger = logger;
            this.jsonSerializer = jsonSerializer;
        }

        public PaymentResponse DoPayment(PaymentRequest request)
        {
            IPARAConfiguration iParaConfiguration = jsonSerializer.Deserialize<IPARAConfiguration>(request.Configuration);

            return new PaymentResponse
            {
                IsSucceed = true
            };
        }
    }
}
