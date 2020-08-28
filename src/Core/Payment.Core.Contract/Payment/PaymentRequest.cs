namespace Payment.Core.Contract.Payment
{
    public class PaymentRequest : PaymentBase
    {
        public int Installment { get; set; }
        public string Cvc { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
    }
}
