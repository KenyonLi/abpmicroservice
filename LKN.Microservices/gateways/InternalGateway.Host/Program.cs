using InternalGateway.Host;
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
               .UseAutofac();

//builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("appsettings.json")
//                   // .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
//                    .AddEnvironmentVariables(); 

builder.Services.AddApplication<InternalGatewayHostModule>();


//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();
app.InitializeApplication();
await app.RunAsync();


//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
