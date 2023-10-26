using Volo.Abp.MongoDB;

namespace LKN.Product.MongoDB;

public class ProductMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
{
    public ProductMongoModelBuilderConfigurationOptions(string collectionPrefix = "") : base(collectionPrefix)
    {
    }
}