using Volo.Abp.Modularity;

namespace LKN.Order;

[DependsOn(
    typeof(OrderApplicationModule),
    typeof(OrderDomainTestModule)
    )]
public class OrderApplicationTestModule : AbpModule
{

}
