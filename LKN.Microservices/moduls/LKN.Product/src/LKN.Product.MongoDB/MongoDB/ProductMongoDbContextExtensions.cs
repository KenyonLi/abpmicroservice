using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace LKN.Product.MongoDB;

public static class ProductMongoDbContextExtensions
{
    public static void ConfigureProduct(
        this IMongoModelBuilder builder,
        Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));
        var options = new ProductMongoModelBuilderConfigurationOptions(
                ProductDbProperties.DbTablePrefix
            );

        optionsAction?.Invoke(options);

        // 1、创建商品模型对应的表
        builder.Entity<Products.Product>(b =>
        {
            b.CollectionName = "Products";
        });
    }
}
