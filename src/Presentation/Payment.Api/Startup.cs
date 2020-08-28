using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Payment.AppService.Bootstrapper;
using Payment.Core.Contract.AppSettings;

namespace Payment.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly AppSettings appSettings;

        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();

            this.configuration = builder.Build();

            appSettings = new AppSettings();
            var section = configuration.GetSection("AppSettings");
            new ConfigureFromConfigurationOptions<AppSettings>(section).Configure(appSettings);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                BaseBootstrapper bootstrapper = new BaseBootstrapper(services, cfg);
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton(appSettings);
            services.AddSingleton<IAppSettings>(appSettings);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
