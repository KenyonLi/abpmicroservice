using System;
using System.IO;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using Serilog;
using Serilog.Events;

namespace LKN.Order;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
               .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
               .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .WriteTo.Async(c => c.File("Logs/logs.txt"))
#if DEBUG
               .WriteTo.Async(c => c.Console())
#endif
                 .CreateLogger();
        try
        {
            Log.Information("Starting web host.");
            var builder = WebApplication.CreateBuilder(args);

            //var HostingEnvironment = builder.Environment;
            // var cfg = LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), $"/nlog.{HostingEnvironment.EnvironmentName}.config"));
            //// 2、根据环境变量加载NLog配置文件
            //NLogBuilder.ConfigureNLog(cfg.Configuration);

            builder.Host.AddAppSettingsSecretsJson()
                    
                   .ConfigureAppConfiguration((context, build) =>
                     {
                         //build.AddJsonFile("appsettings.secrets.json", optional: true);
                         //var configuration = build.Build();
                         //var s = configuration.GetSection("Nacos");
                         //build.AddNacosV2Configuration(s);
                     
                     })
                  
                .UseAutofac()
                .UseNLog();
                //.UseSerilog((context,logger) => {
                //    #region Serilog日志
                //        //第一种方式：配置形式进行
                //        logger.ReadFrom.Configuration(context.Configuration);
                //        logger.Enrich.FromLogContext();
                //    //输出到RabbitMQ
                //        logger.WriteTo.RabbitMQ((clientConfiguration, sinkConfiguration) =>
                //        {
                //            clientConfiguration.Hostnames.Add("localhost");
                //            clientConfiguration.Username = "guest";
                //            clientConfiguration.Password = "guest";
                //            clientConfiguration.Exchange = "orderlogsservice";
                //            clientConfiguration.ExchangeType = RabbitMQ.Client.ExchangeType.Direct;
                //            clientConfiguration.DeliveryMode = RabbitMQDeliveryMode.Durable;
                //            clientConfiguration.RouteKey = "orderlogsservicekey";
                //            clientConfiguration.Port = 5672;
                //            sinkConfiguration.TextFormatter = new Serilog.Formatting.Json.JsonFormatter();
                //        });
                //    #endregion

                //});
 
            await builder.AddApplicationAsync<OrderHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
