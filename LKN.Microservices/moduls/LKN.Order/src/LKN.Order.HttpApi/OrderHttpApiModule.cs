using Localization.Resources.AbpUi;
using LKN.Order.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Servicecomb.Saga.Omega.AspNetCore.Extensions;
using LKN.Microservices.Infrastructure.sagas;
using LKN.Microservices.Infrastructure;

namespace LKN.Order;

[DependsOn(
    typeof(OrderApplicationContractsModule),
    typeof(InfrastructureModule),
    typeof(AbpAspNetCoreMvcModule))]
public class OrderHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(OrderHttpApiModule).Assembly);
        });
        //context.Services.AddOmegaCore(option =>
        //{
        //    option.GrpcServerAddress = "localhost:8081"; // 1、协调中心地址
        //    option.InstanceId = "OrderServices-1";// 2、服务实例Id
        //    option.ServiceName = "OrderServices";// 3、服务名称
        //});
 

        context.Services.AddOmegaCoreCluster("servicecomb-alpha-server", "OrderServices");
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<OrderResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });


    }
}
