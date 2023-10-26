using LKN.Product.MongoDB;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace LKN.Product.Products
{
    /// <summary>
    /// 商品仓储实现
    /// </summary>
    [Dependency(ServiceLifetime.Singleton)]
    public class ProductMongoDBRepository : MongoDbRepository<ProductMongoDbContext, Product, Guid>, IProductMongoDBRepository
    {
        public ProductMongoDBRepository(
            IMongoDbContextProvider<ProductMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task DeleteProductByProductStock(int ProductStock)
        {
            // 1、获取MongoDB对应集合
            IMongoCollection<Product> mongoCollections = await GetCollectionAsync();

            // 2、根据库存删除商品
            await mongoCollections.DeleteManyAsync(Builders<Product>.Filter.Eq(b => b.ProductStock, ProductStock));
        }

        /*public override async Task<Products> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            DbSet<Products> products = await GetDbSetAsync();
            return products.Include(p => p.ProductImages).Where(p => p.Id == id).FirstOrDefault();
        }*/

        public IEnumerable<Product> GetProductAndImages()
        {
            /* DbSet<Products> products = GetDbSetAsync().Result;

             return products.Include(product => product.ProductImages).ToList();*/
            return null;
        }

        /// <summary>
        /// 根据商品名称，查询商品
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns></returns>
        public Product GetProductByName(string ProductName)
        {
            /*// 1、第一种实现
            //EBusinessDbContext eBusinessDbContext = GetDbContextAsync().Result;

            // 2、第二种实现，根据名称获取商品
            DbSet<Products>  products = GetDbSetAsync().Result;
            return products.Where(product => product.ProductTitle == ProductName).FirstOrDefault();*/
            return null;
        }
    }
}
