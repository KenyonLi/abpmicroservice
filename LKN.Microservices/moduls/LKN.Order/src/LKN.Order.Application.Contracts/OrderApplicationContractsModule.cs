using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Volo.Abp.PermissionManagement;

namespace LKN.Order;
[DependsOn(
    typeof(OrderDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class OrderApplicationContractsModule : AbpModule
{

}
