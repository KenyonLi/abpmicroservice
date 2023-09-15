using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace LKN.Order;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(OrderDomainSharedModule)
)]
public class OrderDomainModule : AbpModule
{

}
