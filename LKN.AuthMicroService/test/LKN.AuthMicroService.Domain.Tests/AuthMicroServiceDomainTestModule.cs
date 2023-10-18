using LKN.AuthMicroService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LKN.AuthMicroService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(AuthMicroServiceEntityFrameworkCoreTestModule)
    )]
public class AuthMicroServiceDomainTestModule : AbpModule
{

}
