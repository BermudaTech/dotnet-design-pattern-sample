using Bermuda.Core.Logger;
using Bermuda.Core.Serialization;
using Payment.Core.Contract.Payment;
using Payment.Core.Enumeration;
using System.Threading.Tasks;

namespace Payment.Integration.IPARA
{
    public class IPARAPaymentIntegration : PaymentProvider
    {
        private readonly ILogger logger;
        private readonly IJsonSerializer jsonSerializer;
        private readonly IXmlSerializer xmlSerializer;
        private readonly IBankBinQuery bankBinQuery;

        public IPARAPaymentIntegration(
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

        public override ProviderType ProviderType => ProviderType.IPARA;

        public override async Task<PaymentResponse> DoPaymentAsync(PaymentRequest request)
        {
            IPARAConfiguration iParaConfiguration = jsonSerializer.Deserialize<IPARAConfiguration>(request.Configuration);

            await Task.Delay(1000);

            return new PaymentResponse
            {
                IsSucceed = true
            };
        }
    }
}
