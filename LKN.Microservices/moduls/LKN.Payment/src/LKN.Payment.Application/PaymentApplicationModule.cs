using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace LKN.Payment;

[DependsOn(
    typeof(PaymentDomainModule),
    typeof(PaymentApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class PaymentApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<PaymentApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<PaymentApplicationModule>(validate: false);
            // true：代表映射两个类，字段个数要一直。进行校验。
            // false: 不做任何校验，只有有相同的字段就做映射
        });
    }
}
