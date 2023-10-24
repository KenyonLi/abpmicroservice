using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LKN.AuthMicroService.EntityFrameworkCore;

[DependsOn(
    typeof(AuthMicroServiceDomainModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AbpIdentityServerEntityFrameworkCoreModule),// 集成 IdentityServer
    typeof(AbpIdentityEntityFrameworkCoreModule) // 集成权限管理
)]
public class AuthMicroServiceEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AuthMicroServiceDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
