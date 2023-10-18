using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LKN.AuthMicroService;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AuthMicroServiceHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class AuthMicroServiceConsoleApiClientModule : AbpModule
{

}
