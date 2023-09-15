using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace LKN.Payment;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class PaymentInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PaymentInstallerModule>();
        });
    }
}
