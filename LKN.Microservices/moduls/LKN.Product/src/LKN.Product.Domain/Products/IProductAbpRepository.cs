﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LKN.Product.Products
{
    public interface IProductAbpRepository: IRepository<Product,Guid>
    {
        IEnumerable<Product> GetProductAndImages();
        IEnumerable<Product> GetProductByName(string productName);
    }
}
