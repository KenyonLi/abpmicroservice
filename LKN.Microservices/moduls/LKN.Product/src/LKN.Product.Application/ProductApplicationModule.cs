using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.Autofac;
using Volo.Abp.BlobStoring.Minio;
using Volo.Abp.BlobStoring;

namespace LKN.Product;

[DependsOn(
    typeof(ProductDomainModule),
    typeof(ProductApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpAutofacModule),
    typeof(AbpBlobStoringModule),
    typeof(AbpBlobStoringMinioModule)
    )]
public class ProductApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ProductApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ProductApplicationModule>(validate: false);
        });
    }
}
