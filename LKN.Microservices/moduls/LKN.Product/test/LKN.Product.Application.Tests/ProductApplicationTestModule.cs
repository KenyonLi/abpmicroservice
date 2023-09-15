using Volo.Abp.Modularity;

namespace LKN.Product;

[DependsOn(
    typeof(ProductApplicationModule),
    typeof(ProductDomainTestModule)
    )]
public class ProductApplicationTestModule : AbpModule
{

}
