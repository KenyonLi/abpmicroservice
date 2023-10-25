using InternalGateway.Host;
using NLog.Web;
using Serilog;
using Serilog.Events;
/*
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
*/

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .Enrich.WithProperty("Application", "InternalGateway")
    .Enrich.FromLogContext()
    // .WriteTo.File("Logs/logs.txt")
    .WriteTo.Console()
    /*.WriteTo.Elasticsearch(
        new ElasticsearchSinkOptions(new Uri(configuration["ElasticSearch:Url"]))
        {
            AutoRegisterTemplate = true,
            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
            IndexFormat = "msdemo-log-{0:yyyy.MM}"
        })*/
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("appsettings.json")
//                   // .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
//                    .AddEnvironmentVariables(); 

builder.Services.AddApplication<InternalGatewayHostModule>();


var app = builder.Build();
app.InitializeApplication();
await app.RunAsync();
