using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LKN.Microservices.ClientHttps;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpHttpClientIdentityModelModule) // 配置AbpIdentityModel
)]
public class ClientHttpsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        base.ConfigureServices(context);
       
    }
    
    public override Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
    {
       
        var logger = context.ServiceProvider.GetRequiredService<ILogger<ClientHttpsModule>>();
        var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
        logger.LogInformation($"MySettingName => {configuration["MySettingName"]}");

        var hostEnvironment = context.ServiceProvider.GetRequiredService<IHostEnvironment>();
        logger.LogInformation($"EnvironmentName => {hostEnvironment.EnvironmentName}");

        return Task.CompletedTask;
    }
}
