using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace LKN.AuthMicroService;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class AuthMicroServiceInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AuthMicroServiceInstallerModule>();
        });
    }
}
