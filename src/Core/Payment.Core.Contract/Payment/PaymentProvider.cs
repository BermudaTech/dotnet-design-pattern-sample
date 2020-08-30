using Bermuda.Core.Logger;
using Bermuda.Core.Serialization;
using Payment.Core.Enumeration;
using System.Threading.Tasks;

namespace Payment.Core.Contract.Payment
{
    public abstract class PaymentProvider
    {
        private readonly ILogger logger;
        private readonly IJsonSerializer jsonSerializer;
        private readonly IXmlSerializer xmlSerializer;
        private readonly IBankBinQuery bankBinQuery;

        protected PaymentProvider(
            ILogger logger,
            IJsonSerializer jsonSerializer,
            IXmlSerializer xmlSerializer,
            IBankBinQuery bankBinQuery)
        {
            this.logger = logger;
            this.jsonSerializer = jsonSerializer;
            this.xmlSerializer = xmlSerializer;
            this.bankBinQuery = bankBinQuery;
        }

        public abstract ProviderType ProviderType { get; }

        public abstract Task<PaymentResponse> DoPaymentAsync(PaymentRequest request);

        public virtual async Task<GetBankByBinNumberResponse> GetBankByBinNumberAsync(GetBankByBinNumberRequest request)
        {
            return await bankBinQuery.GetBankByBinNumberAsync(request);
        }
    }
}
