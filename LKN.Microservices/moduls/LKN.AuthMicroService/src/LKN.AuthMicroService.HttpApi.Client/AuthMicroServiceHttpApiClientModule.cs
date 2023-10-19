using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace LKN.AuthMicroService;

[DependsOn(
    typeof(AuthMicroServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AuthMicroServiceHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "AuthMicroService";
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AuthMicroServiceApplicationContractsModule).Assembly,
           // AuthMicroServiceRemoteServiceConsts.RemoteServiceName
           RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AuthMicroServiceHttpApiClientModule>();
        });

    }
}
