using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using LKN.Order.Localization;
using Volo.Abp.Domain;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.PermissionManagement;

namespace LKN.Order;
[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpDddDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule)
)]
public class OrderDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OrderDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<OrderResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Order");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Order", typeof(OrderResource));
        });
    }
}
