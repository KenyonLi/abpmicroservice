using Localization.Resources.AbpUi;
using LKN.Product.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Servicecomb.Saga.Omega.AspNetCore.Extensions;
using LKN.Microservices.Infrastructure.sagas;
using LKN.Microservices.Infrastructure;

namespace LKN.Product;

[DependsOn(
    typeof(ProductApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ProductHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ProductHttpApiModule).Assembly);
        });

    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ProductResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });

        // 1、分布式事务
        //context.Services.AddOmegaCore(option =>
        //{
        //    option.GrpcServerAddress = "localhost:8081"; // 1、协调中心地址
        //    option.InstanceId = "ProductServices-1";// 2、服务实例Id
        //    option.ServiceName = "ProductServices";// 3、服务名称
        //});
        //context.Services.AddOmegaCoreCluster("servicecomb-alpha-server", "ProductServices");
    }
}
