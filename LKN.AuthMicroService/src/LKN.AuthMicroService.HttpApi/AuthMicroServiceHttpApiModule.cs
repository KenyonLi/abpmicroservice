using Localization.Resources.AbpUi;
using LKN.AuthMicroService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace LKN.AuthMicroService;

[DependsOn(
    typeof(AuthMicroServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AuthMicroServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AuthMicroServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AuthMicroServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
