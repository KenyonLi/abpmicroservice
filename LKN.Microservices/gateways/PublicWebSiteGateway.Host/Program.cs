using Serilog.Events;
using Serilog;
using PublicWebSiteGateway.Host;

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
               .ConfigureAppConfiguration(build => {
                   // 1°¢º”‘ÿnacos≈‰÷√
                  var configuration = build.Build();
                  build.AddNacosV2Configuration(configuration.GetSection("Nacos"));
               })
               .UseAutofac();

builder.Services.AddApplication<PublicWebSiteGatewayHostModule>();

var app = builder.Build();
app.InitializeApplication();
await app.RunAsync();
