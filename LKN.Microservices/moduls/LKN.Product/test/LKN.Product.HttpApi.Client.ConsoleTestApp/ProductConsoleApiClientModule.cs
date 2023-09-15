using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LKN.Product;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProductHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ProductConsoleApiClientModule : AbpModule
{

}
