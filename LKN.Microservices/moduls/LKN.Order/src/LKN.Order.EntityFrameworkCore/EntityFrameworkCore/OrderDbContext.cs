using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
namespace LKN.Order.EntityFrameworkCore;

[ConnectionStringName(OrderDbProperties.ConnectionStringName)]
public class OrderDbContext : AbpDbContext<OrderDbContext>, IOrderDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<LKN.Order.Orders.Order> Order { get; set; } // 配置订单领域(以领域为单位)


    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureOrder();
    }
}
