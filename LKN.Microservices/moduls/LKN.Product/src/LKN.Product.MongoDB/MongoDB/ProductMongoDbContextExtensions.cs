using Volo.Abp;
using Volo.Abp.MongoDB;

namespace LKN.Product.MongoDB;

public static class ProductMongoDbContextExtensions
{
    public static void ConfigureProduct(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
