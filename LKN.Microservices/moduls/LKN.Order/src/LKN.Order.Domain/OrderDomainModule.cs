using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;

namespace LKN.Order;
[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(OrderDomainSharedModule),
    typeof(AbpPermissionManagementDomainModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementDomainIdentityServerModule)
)]
public class OrderDomainModule : AbpModule
{

}
