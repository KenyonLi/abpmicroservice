using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace LKN.Order;

[DependsOn(
    typeof(OrderApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class OrderHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Order";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(OrderApplicationContractsModule).Assembly,
             RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OrderHttpApiClientModule>();
        });

    }
}
