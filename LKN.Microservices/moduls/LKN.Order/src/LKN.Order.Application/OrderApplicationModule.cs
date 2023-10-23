using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.PermissionManagement;

namespace LKN.Order;
[DependsOn(
    typeof(OrderDomainModule),
    typeof(OrderApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class OrderApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<OrderApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<OrderApplicationModule>(validate: false);
        });
    }
}
