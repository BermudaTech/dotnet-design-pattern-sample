using AutoMapper;
using Bermuda.Core.Database.ContextFactory;
using Bermuda.Core.Logger;
using Bermuda.Core.Mapper;
using Bermuda.Core.Repository.UnitOfWork;
using Bermuda.Core.Serialization;
using Bermuda.Infrastructure.Database.UnitOfWork;
using Bermuda.Infrastructure.Logger;
using Bermuda.Infrastructure.Mapper;
using Bermuda.Infrastructure.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Payment.AppService.Contract.Service;
using Payment.AppService.Service;
using Payment.Domain.EntityMigration.Context;
using Payment.Domain.Repository;
using Payment.Domain.Repository.ContextFactory;
using Payment.Domain.Service;
using Payment.Domain.Validation;

namespace Payment.AppService.Bootstrapper
{
    public class BaseBootstrapper
    {
        private readonly IServiceCollection services;
        private readonly IMapperConfigurationExpression mapperConfiguration;

        public BaseBootstrapper(
            IServiceCollection services,
            IMapperConfigurationExpression mapperConfiguration)
        {
            this.services = services;
            this.mapperConfiguration = mapperConfiguration;

            Install();
        }

        private void Install()
        {
            services.AddTransient<IDbContextFactory, DbContextFactory>();
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddTransient<IJsonSerializer, JsonSerializer>();
            services.AddTransient<IXmlSerializer, XmlSerializer>();
            services.AddTransient<IClassMapper, ClassMapper>();
            services.AddTransient<ILogger, Log4NetLogger>();

            Log4NetLogger.Init();

            services.AddTransient<IPaymentService, PaymentService>();

            services.AddTransient<BankDomainService>();
            services.AddTransient<ProviderDomainService>();

            services.AddTransient<IBankBinRepository, BankBinRepository>();
            services.AddTransient<IBankProviderRepository, BankProviderRepository>();
            services.AddTransient<IProviderRepository, ProviderRepository>();

            services.AddTransient<IBankValidation, BankValidation>();

            ContractToDomainModelMapping();
            DomainToContractModelMapping();

            using (PaymentDbContext context = new PaymentDbContext())
            {
                context.Database.Migrate();
            }
        }

        private void ContractToDomainModelMapping()
        {

        }

        private void DomainToContractModelMapping()
        {

        }
    }
}
