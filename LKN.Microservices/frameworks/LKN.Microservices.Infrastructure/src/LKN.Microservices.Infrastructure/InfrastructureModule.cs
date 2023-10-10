using System;
using System.Threading.Tasks;
using LKN.Microservices.Infrastructure.Registry.Extentions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LKN.Microservices.Infrastructure;

[DependsOn(
    typeof(AbpAutofacModule)
)]
public class InfrastructureModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostEnvironment = context.Services.GetSingletonInstance<IHostEnvironment>();

        context.Services.AddServiceRegistry(options =>
        {
            options.ServiceId = Guid.NewGuid().ToString();
            options.ServiceName = configuration["ConsulRegistry:ServiceName"];
            options.ServiceAddress = Environment.GetEnvironmentVariable("ASPNETCORE_URLS") != null ? Environment.GetEnvironmentVariable("ASPNETCORE_URLS") : configuration["ConsulRegistry:ServiceAddress"];//"https://localhost:5002";
            options.HealthCheckAddress = configuration["ConsulRegistry:HealthCheckAddress"];
            options.RegistryAddress = configuration["ConsulRegistry:RegistryAddress"];//"http://localhost:8500";
        });

    }
    public override Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        var logger = context.ServiceProvider.GetRequiredService<ILogger<InfrastructureModule>>();
        var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
        logger.LogInformation($"MySettingName => {configuration["MySettingName"]}");

        var hostEnvironment = context.ServiceProvider.GetRequiredService<IHostEnvironment>();
        logger.LogInformation($"EnvironmentName => {hostEnvironment.EnvironmentName}");

        return Task.CompletedTask;
    }
}
