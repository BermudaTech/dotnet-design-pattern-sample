using Bermuda.Core.Mapper;
using Bermuda.Core.Repository.UnitOfWork;
using Payment.AppService.Contract.Model.Payment;
using Payment.AppService.Contract.Service;
using Payment.Core.Contract.Payment;
using Payment.Domain.Entity;
using Payment.Domain.Service;
using System.Threading.Tasks;

namespace Payment.AppService.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IClassMapper classMapper;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly BankDomainService bankDomainService;
        private readonly ProviderDomainService providerDomainService;

        public PaymentService(
            IClassMapper classMapper,
            IUnitOfWorkFactory unitOfWorkFactory,
            BankDomainService bankDomainService,
            ProviderDomainService providerDomainService)
        {
            this.classMapper = classMapper;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.bankDomainService = bankDomainService;
            this.providerDomainService = providerDomainService;
        }

        public async Task<DoPaymentResponse> DoPaymentAsync(DoPaymentRequest request)
        {
            DoPaymentResponse response = new DoPaymentResponse();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.Begin();

                BankBin bankBin = await bankDomainService.GetValidBankBinByCardNumberAsync(unitOfWork, request.CardNumber);

                BankProvider bankProvider = await bankDomainService.GetValidBankProviderByBankIdAsync(unitOfWork, bankBin.BankId);

                Provider provider = await providerDomainService.GetValidProviderByIdAsync(unitOfWork, bankProvider.ProviderId);

                IPaymentProvider paymentProvider = providerDomainService.GetValidPaymentProviderByType(provider.ProviderType);

                PaymentRequest paymentRequest = classMapper.Map<DoPaymentRequest, PaymentRequest>(request);
                paymentRequest.SetConfiguration(bankProvider.Configuration);

                paymentProvider.DoPayment(paymentRequest);

                unitOfWork.Commit();
            }

            return response;
        }
    }
}
