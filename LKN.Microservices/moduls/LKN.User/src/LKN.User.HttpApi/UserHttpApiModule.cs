using Localization.Resources.AbpUi;
using LKN.User.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace LKN.User;

[DependsOn(
    typeof(UserApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class UserHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(UserHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<UserResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
