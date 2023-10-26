using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LKN.Product.Products
{
    /// <summary>
    /// 商品仓储
    /// 1、做定制化
    /// </summary>
    public interface IProductMongoDBRepository : IRepository<Product, Guid>
    {
        Product GetProductByName(string ProductName);

        /// <summary>
        /// 查询和图片
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProductAndImages();

        public Task DeleteProductByProductStock(int ProductStock);
    }
}
