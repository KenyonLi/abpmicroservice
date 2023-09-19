using LKN.Product.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.DependencyInjection;

namespace LKN.Product.Products
{
    /// <summary>
    /// 商品仓储实现
    /// </summary>
    [Dependency(ServiceLifetime.Transient)]
    public class ProductRepository : IProductRepository
    {
        public ProductDbContext _eBusinessDbContext;
        public ProductRepository(ProductDbContext eBusinessDbContext)
        {
            this._eBusinessDbContext = eBusinessDbContext;
        }
        public void Create(Product Product)
        {
            _eBusinessDbContext.Product.Add(Product);
            _eBusinessDbContext.SaveChanges();
        }

        public void Delete(Product Product)
        {
            _eBusinessDbContext.Product.Remove(Product);
            _eBusinessDbContext.SaveChanges();
        }

        public Product GetProductById(Guid id)
        {
            return _eBusinessDbContext.Product.FirstOrDefault(p=>p.Id ==id);
        }

        public Product GetProductByName(string ProductName)
        {
            return _eBusinessDbContext.Product.FirstOrDefault(e => e.ProductTitle == ProductName);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _eBusinessDbContext.Product.ToList();
        }

        public bool ProductExists(Guid id)
        {
            return _eBusinessDbContext.Product.Any(e => e.Id == id);
        }

        public void Update(Product Product)
        {
            _eBusinessDbContext.Product.Update(Product);
            _eBusinessDbContext.SaveChanges();
        }
    }
}
