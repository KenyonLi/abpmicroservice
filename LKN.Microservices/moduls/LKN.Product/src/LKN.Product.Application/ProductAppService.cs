using LKN.Product.Localization;
using Volo.Abp.Application.Services;

namespace LKN.Product;

public abstract class ProductAppService : ApplicationService
{
    protected ProductAppService()
    {
        LocalizationResource = typeof(ProductResource);
        ObjectMapperContext = typeof(ProductApplicationModule);
    }
}
