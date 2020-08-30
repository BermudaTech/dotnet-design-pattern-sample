using Bermuda.Core.Logger;
using Bermuda.Core.Serialization;
using Payment.Core.Contract.Payment;
using Payment.Core.Enumeration;
using System.Threading.Tasks;

namespace Payment.Integration.MPI
{
    public class MPIPaymentIntegration : PaymentProvider
    {
        private readonly ILogger logger;
        private readonly IJsonSerializer jsonSerializer;
        private readonly IXmlSerializer xmlSerializer;
        private readonly IBankBinQuery bankBinQuery;

        public MPIPaymentIntegration(
            ILogger logger,
            IJsonSerializer jsonSerializer,
            IXmlSerializer xmlSerializer,
            IBankBinQuery bankBinQuery) : base(logger, jsonSerializer, xmlSerializer, bankBinQuery)
        {
            this.logger = logger;
            this.jsonSerializer = jsonSerializer;
            this.xmlSerializer = xmlSerializer;
            this.bankBinQuery = bankBinQuery;
        }

        public override ProviderType ProviderType => ProviderType.MPI;

        public override async Task<PaymentResponse> DoPaymentAsync(PaymentRequest request)
        {
            MPIConfiguration mpiConfiguration = jsonSerializer.Deserialize<MPIConfiguration>(request.Configuration);

            await Task.Delay(1000);

            return new PaymentResponse
            {
                IsSucceed = true
            };
        }
    }
}
