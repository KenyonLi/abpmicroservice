using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace LKN.AuthMicroService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AuthMicroServiceDomainSharedModule)
)]
public class AuthMicroServiceDomainModule : AbpModule
{

}
