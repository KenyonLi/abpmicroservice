using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace LKN.AuthMicroService.MongoDB;

[DependsOn(
    typeof(AuthMicroServiceDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class AuthMicroServiceMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<AuthMicroServiceMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
