using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace LKN.User;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(UserDomainSharedModule)
)]
public class UserDomainModule : AbpModule
{

}
