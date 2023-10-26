using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LKN.Product.MongoDB;

[ConnectionStringName(ProductDbProperties.ConnectionMonogDBStringName)]//需要创建一个远程连接字符串地址
public class ProductMongoDbContext : AbpMongoDbContext, IProductMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<LKN.Product.Products.Product> Products => Collection<LKN.Product.Products.Product>(); // 创建商品模型
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureProduct();
    }
}
