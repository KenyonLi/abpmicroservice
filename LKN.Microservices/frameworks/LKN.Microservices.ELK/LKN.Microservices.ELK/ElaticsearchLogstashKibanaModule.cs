using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog.Formatting.Json;
using Serilog.Sinks.RabbitMQ;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Serilog.Core;
using NLog.Web;

namespace LKN.Microservices.ELK
{

    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class ElaticsearchLogstashKibanaModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostEnvironment = context.Services.GetSingletonInstance<IHostEnvironment>();
            // 2、根据环境变量加载NLog配置文件
            NLogBuilder.ConfigureNLog($"nlog.{hostEnvironment.EnvironmentName}.config");
          //  context.Services.AddSingleton<ILog, LogNLog>();

           // Log.Logger = new LoggerConfiguration()
           //                     .Enrich.FromLogContext()
           //                     .WriteTo.Console()
           //                     //.Enrich.WithProperty("ApplicationName", "Serilog.Sinks.LogstashHttp.ExampleApp")
           //                    // .WriteTo.LogstashHttp("https://elk-host:8443")
           //                     .WriteTo.RabbitMQ((clientConfiguration, sinkConfiguration) =>
           //                     {
           //                         clientConfiguration.Username = configuration["ElkRabbitMq:RABBITMQ_USER"];
           //                         clientConfiguration.Password = configuration["ElkRabbitMq:RABBITMQ_PASSWORD"];
           //                         clientConfiguration.Exchange = configuration["ElkRabbitMq:RABBITMQ_EXCHANGE"];
           //                         clientConfiguration.ExchangeType = configuration["ElkRabbitMq:RABBITMQ_EXCHANGE_TYPE"];
           //                         clientConfiguration.DeliveryMode = RabbitMQDeliveryMode.Durable;
           //                         clientConfiguration.RouteKey = configuration["ElkRabbitMq:RouteKey"];
           //                         var elkRabbitMq = configuration.GetSection("ElkRabbitMq");

           //                         clientConfiguration.Port = elkRabbitMq.GetValue<int>("Port");
           //                         var HostNames = elkRabbitMq.GetValue<string>("RABBITMQ_HOSTNAMES").Split(",").ToList();
           //                         foreach (string  hostname in HostNames)
           //                         {
           //                             clientConfiguration.Hostnames.Add(hostname);
           //                         }

           //                         sinkConfiguration.TextFormatter = new JsonFormatter();
           //                     }).CreateLogger();


           // var loggerFactory = new LoggerFactory();
           // loggerFactory
           //   .AddSerilog();//if you are not assigning the logger to Log.Logger, then you need to add your logger here.
           //   //.AddConsole(LogLevel.Information);
           //context.Services.AddSingleton<ILoggerFactory>(loggerFactory);

        }
        public override Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            var logger = context.ServiceProvider.GetRequiredService<ILogger<ElaticsearchLogstashKibanaModule>>();
            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            logger.LogInformation($"MySettingName => {configuration["MySettingName"]}");

            var hostEnvironment = context.ServiceProvider.GetRequiredService<IHostEnvironment>();
            logger.LogInformation($"EnvironmentName => {hostEnvironment.EnvironmentName}");

            return Task.CompletedTask;
        }
    }
}
