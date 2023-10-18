using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace LKN.AuthMicroService;

[DependsOn(
    typeof(AuthMicroServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AuthMicroServiceApplicationContractsModule : AbpModule
{

}
