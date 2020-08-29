using AutoMapper;
using Bermuda.Core.Database.ContextFactory;
using Bermuda.Core.Logger;
using Bermuda.Core.Mapper;
using Bermuda.Core.Repository.UnitOfWork;
using Bermuda.Core.Serialization;
using Bermuda.Infrastructure.Database.UnitOfWork;
using Bermuda.Infrastructure.Mapper;
using Microsoft.AspNetCore.Http;
using Moq;
using Payment.AppService.Contract.Model.Payment;
using Payment.AppService.Contract.Service;
using Payment.AppService.Service;
using Payment.Core.Contract.Payment;
using Payment.Domain.Repository;
using Payment.Domain.Repository.ContextFactory;
using Payment.Domain.Service;
using Payment.Domain.Validation;
using Payment.Integration.EST;
using Payment.Integration.IPARA;
using Payment.Integration.MPI;
using Payment.Integration.PAYTEN;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Payment.Test.AppService
{
    public class PaymentServiceTest
    {
        private readonly Mock<ILogger> logger;
        private readonly Mock<IJsonSerializer> jsonSerializer;
        private readonly IClassMapper classMapper;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly Mock<IHttpContextAccessor> httpContextAccessor;
        private readonly IDbContextFactory dbContextFactory;
        private readonly IBankBinRepository bankBinRepository;
        private readonly IBankProviderRepository bankProviderRepository;
        private readonly IBankValidation bankValidation;
        private readonly BankDomainService bankDomainService;
        private readonly IProviderRepository providerRepository;
        private readonly IProviderValidation providerValidation;
        private readonly ProviderDomainService providerDomainService;
        private readonly IPaymentService paymentService;

        public PaymentServiceTest()
        {
            this.logger = new Mock<ILogger>();
            this.jsonSerializer = new Mock<IJsonSerializer>();

            IEnumerable<IPaymentProvider> paymentProviders = new List<IPaymentProvider>
            {
                new ESTPaymentIntegration(logger.Object,jsonSerializer.Object),
                new IPARAPaymentIntegration(logger.Object,jsonSerializer.Object),
                new MPIPaymentIntegration(logger.Object,jsonSerializer.Object),
                new PAYTENPaymentIntegration(logger.Object,jsonSerializer.Object)
            };

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoPaymentRequest, PaymentRequest>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            this.classMapper = new ClassMapper(mapper);
            this.httpContextAccessor = new Mock<IHttpContextAccessor>();
            this.dbContextFactory = new DbContextFactory();
            this.unitOfWorkFactory = new UnitOfWorkFactory(httpContextAccessor.Object, dbContextFactory);
            this.bankBinRepository = new BankBinRepository(unitOfWorkFactory);
            this.bankProviderRepository = new BankProviderRepository(unitOfWorkFactory);
            this.providerRepository = new ProviderRepository(unitOfWorkFactory);
            this.bankValidation = new BankValidation(bankBinRepository, bankProviderRepository);
            this.bankDomainService = new BankDomainService(bankValidation, bankBinRepository);
            this.providerValidation = new ProviderValidation(paymentProviders, providerRepository);
            this.providerDomainService = new ProviderDomainService(providerValidation, providerRepository);
            this.paymentService = new PaymentService(
                classMapper,
                unitOfWorkFactory,
                bankDomainService,
                providerDomainService);
        }

        [Fact]
        public async Task DoPayment()
        {
            DoPaymentResponse response = await paymentService.DoPaymentAsync(new DoPaymentRequest
            {
                CardHolderName = "Tufan DAYI",
                CardNumber = "4183427105342132",
                Cvc = "123",
                ExpireMonth = "12",
                ExpireYear = "2020",
                Installment = 1
            });

            Assert.True(response.IsSuccess);
        }
    }
}
