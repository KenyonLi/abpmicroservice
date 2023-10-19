using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using LKN.AuthMicroService.Localization;
using Volo.Abp.Domain;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.IdentityServer;

namespace LKN.AuthMicroService;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpDddDomainSharedModule),
    typeof(AbpIdentityServerDomainSharedModule)
)]
public class AuthMicroServiceDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AuthMicroServiceDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AuthMicroServiceResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/AuthMicroService");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("AuthMicroService", typeof(AuthMicroServiceResource));
        });
    }
}
