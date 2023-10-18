using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace LKN.AuthMicroService.MongoDB;

[DependsOn(
    typeof(AuthMicroServiceTestBaseModule),
    typeof(AuthMicroServiceMongoDbModule)
    )]
public class AuthMicroServiceMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}
