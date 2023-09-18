using LKN.Order.EntityFrameworkCore;
using LKN.Order.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LKN.Order.Orders
{
    /// <summary>
    /// 商品仓储实现
    /// </summary>
    [Dependency(ServiceLifetime.Transient)]
    public class OrderRepository : EfCoreRepository<OrderDbContext, Order, Guid>, IOrderRepository
    {
        public OrderRepository(
            IDbContextProvider<OrderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

    }
}
