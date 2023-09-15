using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LKN.Order;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OrderHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class OrderConsoleApiClientModule : AbpModule
{

}
