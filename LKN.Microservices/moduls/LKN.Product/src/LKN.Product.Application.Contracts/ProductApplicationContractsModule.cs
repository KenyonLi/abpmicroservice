using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace LKN.Product;

[DependsOn(
    typeof(ProductDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ProductApplicationContractsModule : AbpModule
{

}
