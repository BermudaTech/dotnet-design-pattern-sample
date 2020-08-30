using System.Threading.Tasks;

namespace Payment.Core.Contract.Payment
{
    public interface IBankBinQuery
    {
        Task<GetBankByBinNumberResponse> GetBankByBinNumberAsync(GetBankByBinNumberRequest request);
    }
}
