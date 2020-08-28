namespace Payment.Core.Contract.Payment
{
    public class PaymentBase
    {
        public string Ip { get; set; }
        public string Configuration { get; protected set; }
    }
}
