using Payment.AppService.Contract.Model.Payment;
using System.Threading.Tasks;

namespace Payment.AppService.Contract.Service
{
    public interface IPaymentService
    {
        Task<DoPaymentResponse> DoPaymentAsync(DoPaymentRequest request);
    }
}
