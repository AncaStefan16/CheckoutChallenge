using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Extensions.Configuration;
using PaymentGateway.Configurations;
using PaymentGateway.Infrastructure;
using PaymentGateway.Services;
using System.Data.Entity;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace PaymentGateway.App_Start
{
    public static class IoCConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var configuration = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(HttpRuntime.AppDomainAppPath, "configs"))
               .AddJsonFile("BankServiceConfiguration.json", optional: false, reloadOnChange: false)
               .Build();

            BankServiceConfiguration options = configuration.GetSection("bankservice").Get<BankServiceConfiguration>();
            builder.RegisterInstance<BankServiceConfiguration>(options);
            builder.RegisterType<BankService>().As<IBankService>();
            builder.RegisterType<PaymentService>().As<IPaymentService>();

            builder.RegisterAssemblyTypes(Assembly.Load("PaymentGateway.Infrastructure"))
                  .Where(t => t.Name.EndsWith("Repository"))
                  .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            builder.RegisterType(typeof(PaymentsContext)).As(typeof(DbContext)).InstancePerLifetimeScope();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}