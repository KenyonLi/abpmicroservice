using Volo.Abp.Modularity;

namespace LKN.AuthMicroService;

[DependsOn(
    typeof(AuthMicroServiceApplicationModule),
    typeof(AuthMicroServiceDomainTestModule)
    )]
public class AuthMicroServiceApplicationTestModule : AbpModule
{

}
