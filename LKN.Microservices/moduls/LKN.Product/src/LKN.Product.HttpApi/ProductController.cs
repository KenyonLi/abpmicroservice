using LKN.Product.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LKN.Product;

public abstract class ProductController : AbpControllerBase
{
    protected ProductController()
    {
        LocalizationResource = typeof(ProductResource);
    }
}
