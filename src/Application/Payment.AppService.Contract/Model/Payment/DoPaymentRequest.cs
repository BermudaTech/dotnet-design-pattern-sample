using Bermuda.Core.Contract.Service;

namespace Payment.AppService.Contract.Model.Payment
{
    public class DoPaymentRequest : RequestBase
    {
        public int Installment { get; set; }
        public string Cvc { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
    }
}
