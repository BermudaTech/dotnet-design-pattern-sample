using Bermuda.Core.Logger;
using Bermuda.Core.Serialization;
using Payment.Core.Contract.Payment;
using Payment.Core.Enumeration;

namespace Payment.Integration.MPI
{
    public class MPIPaymentIntegration : IPayment
    {
        public ProviderType ProviderType => ProviderType.MPI;

        private readonly ILogger logger;
        private readonly IJsonSerializer jsonSerializer;

        public MPIPaymentIntegration(
            ILogger logger,
            IJsonSerializer jsonSerializer)
        {
            this.logger = logger;
            this.jsonSerializer = jsonSerializer;
        }

        public PaymentResponse DoPayment(PaymentRequest request)
        {
            MPIConfiguration mpiConfiguration = jsonSerializer.Deserialize<MPIConfiguration>(request.Configuration);

            return new PaymentResponse
            {
                IsSucceed = true
            };
        }
    }
}
