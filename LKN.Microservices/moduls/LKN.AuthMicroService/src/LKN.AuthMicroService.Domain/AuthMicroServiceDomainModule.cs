using Volo.Abp.Domain;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;

namespace LKN.AuthMicroService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AuthMicroServiceDomainSharedModule),
    typeof(AbpIdentityServerDomainModule)
)]
public class AuthMicroServiceDomainModule : AbpModule
{

}
